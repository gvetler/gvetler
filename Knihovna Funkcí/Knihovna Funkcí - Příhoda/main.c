#include "knihovnafunkci.h"

int hodnota = 0b01010110
int bitno = 4;
int nastavenibitu = setBit(hodnota, bitno);
printf("Výsledek: =%d ", nastavenibitu);
int nulovanibitu = clearBit(hodnota, bitno);
printf("Výsledek: =%d ", nulovanibitu);
int zmenabitu = toggleBit(hodnota, bitno);
printf("Výsledek: =%d ", zmenabitu);
bool jebitjedna = bitIsSet(hodnota, bitno);
printf("Výsledek: = ", jebitjedna);
bool jebitnula = bitIsClear(hodnota, bitno);
printf("Výsledek: = ", jebitnula);
