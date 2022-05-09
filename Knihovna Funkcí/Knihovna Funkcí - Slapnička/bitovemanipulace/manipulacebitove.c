#include <stdio.h>
#include <stdbool.h>
#include "knihovna.h"

int main()
{
    int h = 0b01001100;   //76 vstupni hodnota
    int bitno = 4;        //4 bit zacina 0
    h = setBit(h,bitno);
    printf("bit číslo %d byl nastaven do log 1 vzniklo číslo %d",bitno,h);
    h = clearBit(h,bitno);
    printf("\nbit číslo %d byl nastaven do log 0 vzniklo číslo %d",bitno,h);
    h = toggleBit(h,bitno);
    printf("\nbit číslo %d byl nastaven do opačného stavu vzniklo číslo %d",bitno,h);
    int stav = bitIsClear(h,bitno);
    if(stav = 1)
    {
      printf("\nbit číslo %d je log 0 ",bitno);
    }
    else
    {
      printf("\nbit číslo %d není log 0",bitno);
    }
    //printf("\nbit číslo %d je ve stavu nula pokud je číslo %d v 1 pokud je nula tak není prázdný",bitno,stav);
    stav = bitIsSet(h,bitno);
    if(stav = 1)
    {
      printf("\nbit číslo %d je log 1 ",bitno);
    }
    else
    {
      printf("\nbit číslo %d není log 1",bitno);
    }
    //printf("\n%d",stav);
    return 0;
}
