#include <sys/io.h>
#include <stdio.h>
#include <time.h>

int datovyPin = 0;
int modPin = 7;

int stavP1 = 0xFF;

int zpozdeni = 10;

void delay(int milisekundy) {
    struct timespec tim;
    tim.tv_sec = 0;
    tim.tv_nsec = milisekundy*1000000;
    nanosleep(&tim, NULL);
}

int zapnoutBit(int vstup, int cisloBitu) {
    return vstup|(1<<cisloBitu);
}

int vypnoutBit(int vstup, int cisloBitu) {
    return vstup&~(1<<cisloBitu);
}

void nastaveniPrijimace() {
    stavP1 = zapnoutBit(stavP1, modPin);
    outb(stavP1, 0x300);
}

int vstupAktivni(int vstup, int cisloBitu) {
    if(vstup&(1<<cisloBitu) != 0) {
        return 1;
    }
    return 0;
}

int main(void) {
    if(ioperm(0x300,1,1) != 0) {
        printf("Nebyla udelena prava\n");
        return 0;
    }

    nastaveniPrijimace();
    while(1) {
    
        int pocetBitu = 7;
        
        int hodnotaPismena = 0;
        
        delay(zpozdeni);
        
        while(vstupAktivni(inb(0x300), datovyPin) != 0);
        delay(zpozdeni);
        delay(zpozdeni/2);

        while(pocetBitu>=0) {
        	int nactenaHodnota = vstupAktivni(inb(0x300), datovyPin);
        	
        	hodnotaPismena += nactenaHodnota<<pocetBitu;
        	delay(zpozdeni);
        	pocetBitu--;
        }
        
        if(hodnotaPismena == 13) {
    	    printf("\n");
        }
        else {
    	    printf("%c", hodnotaPismena);
        }
    }
    
    return 1;
}