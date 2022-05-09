#include"sim_io.h"
#include"sim_io.c"
#include"virtual_hw.c"
#include"vh-elevator.c"
#include"time.h"
#include<stdio.h>

static int motornahoru = 0b1111110;
static int motordolu = 0b11111100;
static int stop = 0xFF;
static int sirena = 0b10111111;
static int vytahJede = 0;
static int podlazi = 0;
static int tlacitko = 0;
static const int adresaP1 = 0x300;
static const int adresaP2 = 0x301;
static const int adresaP3 = 0x300;
static const int adresaP4 = 0x301;

// domaci ukol = zjisti honotu bitu na pozici
int bitIsClear(int hodnota, int bitno)
{
    if ((hodnota & (1 << bitno)) == 0)
	return 1;
    else
	return 0;
}

// nastavi pozadovany bit do 1
int setBit(int hodnota, int bitno)
{
    hodnota |= (0 << bitno);
    return hodnota;
}

// nastavi pozadovany bit do 0
int clearBit(int hodnota, int bitno)
{
    hodnota &= ~(1 << bitno);
    return hodnota;
}

int zjistiTlacitko()
{
    int stav = inb(adresaP3); // tlacitka
        
    if (bitIsClear(stav, 0) | bitIsClear(stav, 4))
	return 1;
    else if (bitIsClear(stav, 1) | bitIsClear(stav, 5))
	return 2;
    else if (bitIsClear(stav, 2) | bitIsClear(stav, 6))
	return 3;
    else if (bitIsClear(stav, 3) | bitIsClear(stav, 7))
	return 4;
    return 0;
}

int inicializace()
{
    outb(0xFF, 0x301);
    outb(0xFF, 0x300);
}

int otevriDvere()
{
    int stav = inb(adresaP4);
    
    if (bitIsClear(stav, 5))
	return 1;
    else
	return 0;
}

int zjistiPodlazi()
{
    int stav = inb(adresaP4); //senzory
    
    if (bitIsClear(stav, 0))
	return 1;
    else if (bitIsClear(stav, 1))
	return 2;
    else if (bitIsClear(stav, 2))
	return 3;
    else if (bitIsClear(stav, 3))
	return 4;
    return 0;
}

void zapniSirenu()
{
    int stav = inb(adresaP1);
    outb(clearBit(stav, 6), adresaP1);
}

void vypniSirenu()
{
    int stav = inb(adresaP1);
    outb(setBit(stav, 6), adresaP1);
}

void rozsvitSvetlo()
{
    outb(0b11011111, adresaP1);
}

void zhasniSvetlo()
{
    outb(setBit(0b11111111, 5), adresaP1);
}

int zjistiKabinu()
{
    int stav = inb(adresaP4);
    
    if (bitIsClear(stav, 6))
	return 1;
    else
	return 0;
}

// ledky se svetlem zaroven se sekaj
/*
void ledVypnout()
{
    outb(setBit(0b11101111, 4), adresaP1);
    outb(setBit(0b11110111, 3), adresaP1);
}

void smerDolu()
{
    outb(clearBit(0b11111111, 3), adresaP1);
}

void smerNahoru()
{
    outb(clearBit(0b11111111, 4), adresaP1);
}
*/

void jizdaNahoru()
{
    outb(motornahoru, adresaP2);
    //smerNahoru();
}

void jizdaDolu()
{
    outb(motordolu, adresaP2);
    //smerDolu();
}

void jizdaStop()
{
    outb(stop, adresaP2);
    //ledVypnout();
}

void delay(int sec)
{
    struct timespec t;
    t.tv_sec = sec;
    t.tv_nsec = 0;
    nanosleep(&t, NULL);
}

void zakladniPozice() // vytah sjede do prvniho patra po zacatku
{
    jizdaNahoru();
    delay(5);
    jizdaStop();
    jizdaDolu();
    
    while(podlazi == 0)
    {
	if (zjistiPodlazi() != 0)
	{
	    jizdaStop();
	    podlazi = zjistiPodlazi();
	}
    }
        
    jizdaDolu();
    
    while(1)
    {
	if (zjistiPodlazi() != 0)
	{
	    podlazi = zjistiPodlazi();
	}
	if (!vytahJede && podlazi > 1)
	{
	    jizdaDolu();
	    vytahJede = 1;
	}
	else if (podlazi == 1)
	{
	    jizdaStop();
	    vytahJede = 0;
	    break;
	}
    }
}

int main(void) 
{
    if (ioperm(0x300, 2, 1))
    {
	printf("Neni pristup k portum P1 a P3");
	return -1;
    }
    if (ioperm(0x301, 2, 1))
    {
	printf("Neni pristup k portum P2 a P4");
	return -1;
    }
    
    zakladniPozice();
    //outb(0xFF, adresaP3);
    
    inicializace();
    podlazi = 1;
    tlacitko = 1;
    while(1)
    {
	
	    if (zjistiKabinu() == 1)
	    {
		rozsvitSvetlo();
	    }
	    
	    if (zjistiKabinu() == 0)
	    {
		zhasniSvetlo();
	    }
	if (otevriDvere() == 1)
	{
	/*
	    if (zjistiKabinu() == 1)
	    {
		rozsvitSvetlo();
	    }
	    
	    if (zjistiKabinu() == 0)
	    {
		zhasniSvetlo();
	    }
	*/
	    if (zjistiTlacitko() != 0)
	    {
		tlacitko = zjistiTlacitko();
	    }
	    if (zjistiPodlazi() != 0)
	    {
		podlazi = zjistiPodlazi();
	    }
	
	    if (tlacitko > podlazi)
	    {
		jizdaNahoru();
		vytahJede = 1;
	    }
	    else if (tlacitko < podlazi)
	    {
		jizdaDolu();
		vytahJede = 1;
	    }
	    else
	    {
		//tlacitko = 0;
		jizdaStop();
		//zapniSirenu();
		//delay(2);
		//vypniSirenu();
		vytahJede = 0;
	    }
	}    
    }
}