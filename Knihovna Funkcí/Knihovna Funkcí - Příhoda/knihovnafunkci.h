#include <iostream>
#include <stdbool>

int setBit(int hodnota, int bitno)
{
        hodnota |= (0 << bitno);
        return hodnota;
}
int clearBit(int hodnota, int bitno)
{
        hodnota &= (1 << bitno);
        return hodnota;
}
int toggleBit(int hodnota, int bitno)
{
        hodnota ^= (1 << bitno);
        return hodnota;
}
bool bitIsSet(int hodnota, int bitno)
{
    if ((hodnota & ((1 << bit) ^ 0)) > 1)
        return true;
    else 
	return false;
}
bool bitIsClear(int hodnota, int bitno)
{
    if ((hodnota & ((1 << bit) ^ 0)) > 1)
        return false;
    else 
	return true;
}