#include <sys/io.h>
#include <stdio.h>
#include <time.h>

int datovyPin = 6;
int modPin = 7;

int stavP2 = 0xFF;
char odesilanyText[255];

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

void zapsatDataNaPort(int stavPortu) {
    outb(stavPortu, 0x301);
}

int vstupAktivni(int vstup, int cisloBitu) {
    if((vstup&(1<<cisloBitu)) != 0) {
	return 1;
    }
    return 0;
}

void odeslaniZnaku(char* pole, int velikostPole) {
    int i;
    for(i = 0; i<velikostPole; i++) {
	//Odesilani prvni 0
	delay(zpozdeni);
	delay(zpozdeni);
	stavP2 = vypnoutBit(stavP2, datovyPin);
	zapsatDataNaPort(stavP2);
	delay(zpozdeni);
	
	int cisloASCII = pole[i];
	int j;
	for(j = 7; j>=0; j--) {
		int velikostBitu = vstupAktivni(cisloASCII, j);
		if(velikostBitu == 1) {
			stavP2 = zapnoutBit(stavP2, datovyPin);
			zapsatDataNaPort(stavP2);
		}
		else {
			stavP2 = zapnoutBit(stavP2, datovyPin);
			zapsatDataNaPort(stavP2);
			stavP2 = vypnoutBit(stavP2, datovyPin);
			zapsatDataNaPort(stavP2);
		}
		delay(zpozdeni);
	}
	stavP2 = zapnoutBit(stavP2, datovyPin);
	zapsatDataNaPort(stavP2);
	
    }
}

void nastaveniVysilace() {
    stavP2 = vypnoutBit(stavP2, modPin);
    outb(stavP2, 0x301);
}

int spocitatVelikostPole(char* pole) {
    int i = 0;
    while(odesilanyText[i] != '\0') {
        i++;
    }
    return i-1;
}

int main(void) {
    if(ioperm(0x301,1,1) != 0) {
        printf("Nebyla udelena prava\n");
        return 0;
    }
    
    nastaveniVysilace();

    while(1) {
	printf("Napiste na klavesnici, co chcete odeslat.\n");

        fgets(odesilanyText,255,stdin);
    
        int velikost = spocitatVelikostPole(odesilanyText);
        odesilanyText[velikost] = 13;
        velikost++;

        odeslaniZnaku(odesilanyText, velikost);
    }

    return 1;
}