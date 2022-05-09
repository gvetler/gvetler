#include "sim_io.h"
#include "virtual_hw.h"
#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <unistd.h>
#include <time.h>

/** Implementation part of sim_io wrapper. 
*   There's nothing to change or modify, just include in your project as additional source file as is.
*   2020/10/18 Tomas Kolousek - updated, dummy inb() in ioperm to gurantee input image update from virtual hw
*/

// --- supporting routines and locally scoped variables, not part of public interface --- //
/** flag if IO for given address was requested and sucesfully granted */

static bool ioGranted[0x400];
static void die(char *msg, int exitCode) {
    fprintf(stderr,msg);
    exit(exitCode);
}

// --- implementation of public functions for simulated io access --- //
int ioperm(unsigned long from, unsigned long num, int turn_on) {
    if ( (from<0) || (from+num > 0x3ff) || (num <= 0) ) 
	return -1;	// requested address block is invalid
    if (!turn_on) {
	while (num)
	    ioGranted[from+ --num] = false;
	return 0;	// revoke access rights for given io block
    }
    if (geteuid())
	return -1;	// non-root uid of actual process, something telling me that ioperm() should fail then...
    // here when everything is ok
    if (!initIO(VIRTUAL_HW_CLIENTAPP))	// try to initialize virtualized hw fifos, print warning when hw application isn't running
	return -1;	// failed - virtual hw server not running
    while (num) {
	ioGranted[from + num - 1] = true;
	inb(from + --num);	// dummy read to initialize IO state
    }
    struct timespec t = { .tv_nsec=100e+6, .tv_sec=0 };
    nanosleep(&t,NULL);	 // 100ms to be sure input data will be updated from virtual hw app (~50ms per virtual hw app cycle)
    return 0;	// io block access granted 
}

void outb(uint8_t value, unsigned long addr) {
    if (!ioGranted[addr & 0x3ff])
	die("Segmentation fault. (Uhmm, you crashed me by your error - you know what to check ...)\n",-1);
    ePortName p = getPort(dirOUT, addr);
//    printf("outb: %d\n",p);
    if (p != portInvalid)	// port within virtualized hw range
	portWrite(value, p);
    else
	fprintf(stderr,"Uhh ohh - you want me to reset unexpectedly?\n");
}

uint8_t inb(unsigned long addr) {
    if (!ioGranted[addr & 0x3ff])
	die("Segmentation fault. (Uhmm, you crashed me. Be nice and ask before you do something with me ...)\n",-1);
    ePortName p = getPort(dirIN, addr);
    if (p != portInvalid) {	// port within virtualized hw range
	return portRead(p);
    }
    else
	return rand() & 0xff;	// some random port, so return random something :-)
}
