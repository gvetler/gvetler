#include <stdio.h>
#include <stdbool.h>

/*int setBit(int hodnota, int bitno) - nastavení daného bitu hodnoty do log. 1 a vrácení výsledné hodnoty jako návratové hodnoty funkce
int clearBit(int hodnota, int bitno) - viz výše, pro mazání (nulování bitu)
int toggleBit(int hodnota, int _bitno) - viz výše, změna stavu bitu
bool bitIsSet(int hodnota, int bitno) - true (nebo nenulová hodnota při použití návratového typu int) pokud je daný bit v hodnotě nastaven
bool bitIsClear(int hodnota, int bitno) - true pokud je daný bit v log. 0 (zamyslete se, nedá se použít již hotová funkce výše?)*/
int Maska =  0b00000001;
// hodnota = 0b01001100

int setBit(int h, int bitno)
{
  h = h | ( Maska << bitno);    //logicka operace OR nastaveni bitu do log1          0b01001100
  return h;                     // maska posunuta o bitno(4)                       | 0b00010000 = 0b01011100
}

int clearBit(int h, int bitno)
{
  h = h & ( ~(Maska << bitno));  //logicka opearace  AND nastaveni bitu do log0      0b01001100
  return h;                      //negovana maska na bitu 3                        & 0b11110111 = 0b01000100
}

int toggleBit(int h, int bitno)
{
  h = h ^ ( Maska << bitno);      //logicka operace XOR zmena daneho bitu             0b01001100
  return h;                       //maska posunuta o bitno(3)                       ^ 0b00010000 = 0b01011100
}

int bitIsClear(int h, int bitno)
{
  if(h =! (h | (Maska << bitno))) //log OR hodnoty a masky pokud se nerovna h   0b01001100
  {                             // tak true , maska posunuta o bitno(4)    ^  0b00010000  = 0b01011100 hodnota se nerovna bit je ve stavu 0
    return true;
  }
  else
  {
    return false;
   }
}

int bitIsSet(int h, int bitno)
{
  if(h != (h & (~(Maska << bitno))))//log AND hodnoty a negovane masky pokud             0b01001100
  {                                 //se nerovna h tak true, maska posunuto o bitno(3) & 0b11110111 = 0b01000100 se nerovna hodnote takze je bit v 1
    return 1;
  }
  else
  {
    return 0;
  }
}
