#include<stdbool.h>
#include<stdio.h>
int setBit(int hodnota, int bit){  //nastaveni bitu na 1
	hodnota |=(1<<bit);        //hodnota - hodnota kterou chci zmenit
	return hodnota;	           // bit ktery chci zmenit zprava
}
int clearBit(int hodnota, int bit){ //nulovani bitu, stejny princip s hodnotou a bitem
	hodnota &=~ (1<<bit);
	return hodnota;
}
int toggleBit(int hodnota, int bit){ //zmeneni stavu bitu, princip zase stejny
	hodnota  ^= (1<<bit);
	return hodnota;
}

bool bitisSet(int hodnota, int bit){ //posledni bit je 0
	if((hodnota>>bit)&1)
		return 1;
	
		else return 0;
	
}
bool bitisClear(int hodnota, int bit){ //posledni bit je 0 nejvic napravo
	if((hodnota>>bit)&1)
		return 0;
	
		else return 1;
}

