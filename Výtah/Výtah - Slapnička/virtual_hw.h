/** Interface for internals of virtualized hardware ports used on SPS and VOS Chomutov lab lessons
 * @author Tomas Kolousek <t.kolousek@gmail.com>
 * @date   2020-03-23 - updated, synchronous fifo access in portRead/portWrite functions
 * @date   2020-03-15 - created, proof of idea with qnd implementation
 *
 * @details The "server" part, which simulates the hw device, creates 4 fifos under /var/tmp/simIO
 * named according to the real hardware p1,p2 (read by simulated hw) and p3,p4 (written by simulated hw)
 * client the uses sim_io.h + sim_io.c instead of regular sys/io.h for virtualized hw port access.
 * Only ioperm(), inb() and outb() calls covered in sim_io.c client code.
*/

#ifndef VIRTUAL_HW_H
#define VIRTUAL_HW_H

#include <stdint.h>
#define VIRTUAL_HW_SERVERAPP 	0
#define VIRTUAL_HW_CLIENTAPP 	1
#define VIRTUAL_HW_PID		"/var/tmp/virtualhw.pid"

/** Enum for passing portname to various functions using it's symbolic name according to real IO card hardware 
*/
typedef enum { P1 = 0,P2,P3,P4, portCount, portInvalid } ePortName;
/** Enum for specifying IO direction access from point of view of the calling application 
*/
typedef enum { dirIN=0, dirOUT } ePortDirection;
/** Write given value to virtualized IO port. P1/P2 for client, P3/P4 for virtualized hw "server" 
*/
void portWrite(uint8_t value, ePortName port);
/** Read last present value from virtualized IO port fifo. P3/P4 for client, P1/P2 for virtualized hw "server" 
*/
uint8_t portRead(ePortName port);
/** Read actual data from virtualized IO port fifo or -1 when no data are present
*/
int portReadSync(ePortName port);

/** Gets actual data as they was lastly written / read from given port fifo as fifos are unidirectional only.
*/
uint8_t portData(ePortName port);
/** Function connecting io address access in given direction to symbolic port name. Suitable just for client application,
*   virtualized hw "server" application should call portWrite() and portRead() directly.
*   @return symbolic portname (@see ePortname) based on given io operation direction and io address
*   or portInvalid value when no such port is virtualized 
*/ 
ePortName getPort(ePortDirection dir, uint16_t addr);
/** initializes internal data structures, create fifos as needed 
* @parama checkHwPidPresence When non zero, initIO prints warning on console when "server" pidfile isn't present
* @returns -1 when problem with dependent fifo/files and init failed, zero otherwise (like ioperm)
*/
int initIO(int checkHwPidPresence);
/** releases internal data structures and when fifoCleanup is non zero, removes fifos from filesystem **/
void releaseIO(int fifoCleanup);

#endif