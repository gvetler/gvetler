#include "virtual_hw.h"

#define VIRTUAL_HW_FIFO		"/var/tmp/virtualhw"
#define VIRTUAL_HW_BASEADDR	0x300

#include <sys/stat.h>
#include <stdio.h>
#include <unistd.h>
#include <stdlib.h>
#include <signal.h>
#include <fcntl.h>
#include <stdint.h>

// -- internal data structures. declared as static = valid only within scope of actual source file -- //
typedef struct { int fifo; uint8_t lastValue; } sVirtualPort;
static sVirtualPort ports[portCount];
static int initialized = 0;
/** universal character buffer with various use around code. Thread unsafe. */
static char buff[256];

// -- helper and service routines -- //
/** check if file with given name exists and is readable.
*/
static int fileExists(char *filename) {
    int fh = open(filename, O_RDONLY | O_NONBLOCK);
//    printf("file_exists: %d\n",fh);
    if (fh > -1)  {
	close(fh);
	return 1;
    }
    else
	return 0;
}

/** @returns fifo filename for given port or NULL when port is not valid 
*/
static char* fifoName(ePortName port) {
    if (port < portCount)
        snprintf(buff,255,"%s/p%d",VIRTUAL_HW_FIFO,port+1);
    else
	buff[0] = '\0';
    return buff;
}

/** Gets handle of fifo associated with given virtualized io port. If handle is closed, it reopen try is made.
* @returns valid file handle or -1 if handle could not be opened;
*/
static int fifoHandle(ePortName port, ePortDirection direction) {
    if (initialized && (ports[port].fifo != -1)  		// active handle .. 
		&& (fcntl(ports[port].fifo,F_GETFD) != -1) 	// .. still valid, not closed by other side .. 
		&& fileExists(fifoName(port)) )  {		// .. and not removed (fd still valid due to unlink behaviour) .. 
//        printf("fifoHandle(%d,%d,%d,%d) - existing: %d\r\n",port,direction,fileExists(fifoName(port)),ports[port].fifo,fcntl(ports[port].fifo,F_GETFD));
	return ports[port].fifo;	// still valid fifo, use it directly. Obscure, uneffective, non-optimal, but 100% working
    }
	
    // try to open fifo with given direction. For each fifo direction determines first call to portRead()/portWrite() for such port
    char *fname = fifoName(port);
    if (fname) {	// only for valid existing fifo name try to open if with proper mode
	int fd = open(fname, O_NONBLOCK | O_SYNC | ((direction == dirIN) ? O_RDONLY : O_WRONLY) ) ;
	if (ports[port].fifo != -1)	// close actually dead handle 
	    close (ports[port].fifo);
	ports[port].fifo = fd;    // and update with new (or n/a) one
    //    printf("fifoHandle(%d,%d,%s) - reopening: %d\r\n",port,direction,fname,fd);
    }
    return ports[port].fifo;	// for dirOUT could be still failed until reading side of fifo isn't opened
}

int portReadSync(ePortName port) {
    uint8_t data;
    if ( (fifoHandle(port,dirIN) > -1) && (read(ports[port].fifo, &data,1)==1) ) {
	ports[port].lastValue = data;	// data available, remember and return
	return data;
    }
    return -1;	// no data or no fifo accessible
}

void portWriteSync(uint8_t value, ePortName port) {
    if (port>=portCount) {
	fprintf(stderr,"Uhmm, which port you're writing to? Do you want me to crash?\r\n");
	return;
    }

    for (ePortName p=port & 0xf2; p<=(port & 0xf2) + 1;++p) {	// for both accessed ports
	if (fifoHandle(p,dirOUT) > -1)
	    write(ports[p].fifo, (p==port) ? &value : &(ports[p].lastValue), 1);
//	else
//	    fprintf(stderr,"writeSync() no handle for P%d\r\n",p+1);
	if (p == port)
	    ports[port].lastValue = value;
    }
}

// -- implementation of interface routines -- //
void portWrite(uint8_t value, ePortName port) {

    portWriteSync(value,port);
    return;

    if (port>=portCount) {
	fprintf(stderr,"Uhmm, which port you're writing to? Do you want me to crash?\r\n");
	return;
    }
    if (fifoHandle(port,dirOUT) > -1)	{ // write value to fifo if available
	write(ports[port].fifo,&value,1);
    }
//    else
//	printf("portWrite(%d) - n/a\r\n",port);
    ports[port].lastValue = value;	// remember written value for portData()

}

uint8_t portRead(ePortName port) {
    
    while (portReadSync(port)!=-1);	// read all available data, return just last value
    return ports[port].lastValue;
/*
    uint8_t data = ports[port].lastValue;
//    int r = -1;
    if (fifoHandle(port,dirIN) > -1) {	// try to read incomming data from valid fifo
	while(read(ports[port].fifo,&data,1)==1);	// get all available data to prevent delay by fifo "length"
    }
//    printf("portRead: %d %d %d %d\r\n",port,r, data, ports[port].lastValue);
    ports[port].lastValue = data;	// store lastly seen data when no data will be available 
    return data;
*/
}

uint8_t portData(ePortName port) {
//    printf("fifo(%d): %s\n",port,fifoName(port));
    if ( (port<portCount) )
	return ports[port].lastValue;
    return 0;	// request for portCount or portInvalid
}

ePortName getPort(ePortDirection dir, uint16_t addr) {
    if ( (addr<VIRTUAL_HW_BASEADDR) || (addr>=VIRTUAL_HW_BASEADDR + (portCount>>1) ) )
	return portInvalid;		// address not handled by virtualized hw
    if (dir == dirOUT)
	return (addr - VIRTUAL_HW_BASEADDR);	// P1, P2 - outputs from perspective of outb()
    else
	return ( P3 + addr - VIRTUAL_HW_BASEADDR);	// P3, P4 - inputs from perspective of inb()
}

/** Initializes virtualized io fifo files, create fifos if not already present
*/
int initIO(int checkHwPidPresence) {
    char *fname;
    
    if (!initialized) {		// check if virtual hw application is running, print error and fail otherwise
	if (checkHwPidPresence && !fileExists(VIRTUAL_HW_PID) ) {
	    fprintf(stderr,"Uhmmm, I need a buddy to make a party! Is any 'virtual hardware' application running?\r\n");
	    return 0;	// client request without app server, initialization failed
	}
        mkdir(VIRTUAL_HW_FIFO,0777);
        signal(SIGPIPE, SIG_IGN);	// ignore SIGPIPE - broken pipe during read/write operations
	for (int i=0;i<portCount;++i) {	// create fifos, fails and exit when fifo couldn't be created 
	    mkfifo(fname = fifoName(i),0666);
	    if (!fileExists(fname)) {
		fprintf(stderr,"Error: Unable to access %s for hw port P%d virtualization!\r\n",fname,i+1);
		return 0;
	    }
	    // first time initialization of internal "port state" with all fifos closed
	    ports[i].fifo = -1;
	    ports[i].lastValue = (i<=P2 ? 0xff : 0x00); // like on real hw: inputs def. to 0xff (pullups), outputs are 0
	}
    }
    initialized = 1;	// ports array initialized and held calid data
    return 1;
}

/** Cleanup of virtualized io resources, close fifo handles, remove fifo dir when fifoCleanup is non zero 
*/
void releaseIO(int fifoCleanup) {
    for (int i=0;i<portCount;++i) {
	if (ports[i].fifo > -1)
	    close(ports[i].fifo);	// close fifo if actually opened
	if (fifoCleanup)
	    remove(fifoName(i));	// remove fifo port, makes it inacessible to client
    }
    if (fifoCleanup)
	remove(VIRTUAL_HW_FIFO);
    initialized = 0;
}

