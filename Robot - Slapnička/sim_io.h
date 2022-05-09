/** @file   sim_io.h
*   @brief  Simple wrapper for simulating hw io cards used in lab lessons at SPS and VOS Chomutov
*   @date   2020/03/15 - created, proof of concept with basic ioperm()/inb()/outb() semantics
*   @author Tomas Kolousek <t.kolousek@gmail.com>
*/

/** basic necessary subset of functions from @see sys/io.h
*/

#include <stdint.h>
int ioperm(unsigned long from, unsigned long num, int turn_on);
void outb(uint8_t value, unsigned long addr);
uint8_t inb(unsigned long addr);
