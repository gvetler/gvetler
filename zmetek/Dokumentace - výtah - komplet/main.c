#include <sys/io.h>
#include <stdio.h>

int stavP1 = 0xFF;
int stavP2 = 0xFF;
int aktualniPatro = 0;
int cilovePatro = 0;

int kontrolaVnitrnichTlacitek = 0;
int stisknuteTlactiko = 0;

void zobrazitPatro(int cisloPatra) {
	stavP1 = (stavP1 & (~7));
	stavP1 = stavP1 | cisloPatra;
	outb(stavP1, 0x300);
	aktualniPatro = cisloPatra;
}

int zapnoutBit(int vstup, int cisloBitu) {
	vstup = vstup | (1<<cisloBitu);
	return vstup;
}

int vypnoutBit(int vstup, int cisloBitu) {
	vstup = vstup & (~(1<<cisloBitu));
	return vstup;
}

void svetla(int zapnout) {
	if(zapnout == 1) {
		stavP1 = vypnoutBit(stavP1, 5);

	}
	else {
		stavP1 = zapnoutBit(stavP1, 5);
		
	}
	
	outb(stavP1, 0x300);
}

int vstupAktivni(int vstup, int cisloBitu) {
	if((vstup&(1<<cisloBitu)) == 0) {
		return 1;
	}
	else {
		return 0;
	}
}

int kontrolaPater() {
	int i;

	//Kontrola, jestli neni vytah jiz v nekterem patre
	for(i = 0; i<4;i++) {
		if(vstupAktivni(inb(0x301), i) == 1) {
			return (i+1);
		}
	}
	return 0;
}

int kontrolaDveri() {
	int zavreneDvere = vstupAktivni(inb(0x301), 5); //uzavreno 1, otevreno 0
	return zavreneDvere;
}

void startPohybu(int nahoru) {
	if(kontrolaDveri() == 0) {
		svetla(1);
		printf("Dvere nebyly uzavreny. Uzavrete je.\n");
	}

	while(kontrolaDveri() == 0);
	if(osobaUvnitr() == 0) {
	    printf("Osoba uvnitr neni, vypinani svetel\n");
	    svetla(0);
	}
	
	stavP2 = vypnoutBit(stavP2,0); //zapnuti motoru

	if(nahoru == 1) {
		stavP2 = zapnoutBit(stavP2, 1);
	}
	else {
		stavP2 = vypnoutBit(stavP2,1); //zapnuti jizdy dolu
	}
	
	outb(stavP2, 0x301);
}

void stopPohybu() {
	stavP2 = zapnoutBit(stavP2,0);
	outb(stavP2, 0x301);
}

void init(void) {
	outb(0xFF, 0x300);
	outb(0xFF, 0x301);

	int nalezenePatro = kontrolaPater();
	if(nalezenePatro != 0) {
		zobrazitPatro(nalezenePatro);
	}
	else {
		int patroNalezeno = 0;
		int i;
		int poradoveCislo = 0;
		startPohybu(1); //0 - jizda dolu, 1 - jizda nahoru
		while (poradoveCislo < 3500) {
			poradoveCislo++;
			printf("Poradove cislo je: %d\n", poradoveCislo);
		}
		stopPohybu();
		startPohybu(0);
		//oddelovac
		while(patroNalezeno == 0) {
			for(i = 0; i<4;i++) {
				if(vstupAktivni(inb(0x301), i) == 1) {
					zobrazitPatro(i+1);
					patroNalezeno = 1;
					break;
				}	
			}
		}
	stopPohybu();
	}
}

int kontrolaVstupuVnitrni() {
	if (vstupAktivni(inb(0x300), 0) == 1) {
		return 1;
	}
	else if(vstupAktivni(inb(0x300), 1) == 1) {
		return 2;
	}
	else if(vstupAktivni(inb(0x300), 2) == 1) {
		return 3;
	}
	else if(vstupAktivni(inb(0x300), 3) == 1) {
		return 4;
	}
	return 0;
}

int kontrolaVstupuVnejsi() {
	if (vstupAktivni(inb(0x300), 4) == 1) {
		return 1;
	}
	else if(vstupAktivni(inb(0x300), 5) == 1) {
		return 2;
	}
	else if(vstupAktivni(inb(0x300), 6) == 1) {
		return 3;
	}
	else if(vstupAktivni(inb(0x300), 7) == 1) {
		return 4;
	}
	return 0;
}

void prepnoutLED(int ledNahoru) {
	if(ledNahoru == 1) {
		stavP1 = zapnoutBit(stavP1, 4);
		stavP1 = vypnoutBit(stavP1, 3);
	}
	else if(ledNahoru == 0) {
		stavP1 = vypnoutBit(stavP1, 4);
		stavP1 = zapnoutBit(stavP1, 3);
	}
	else {
		stavP1 = zapnoutBit(stavP1, 3);
		stav P1 = zapnoutBit(stavP1, 4);
	}
	outb(stavP1, 0x300);
}

int vytahVPohybu() {
	return vstupAktivni(stavP2, 0);
}

int osobaUvnitr() {
	return vstupAktivni(inb(0x301), 6);
}



int main(void) {
	if(ioperm(0x300,2,1) != 0) {
		printf("Nastala chyba\n");
		return 0;
	}
	init();

	while(1) {
		//Zajisteni svetel
		if(kontrolaDveri() == 0 || osobaUvnitr() == 1) {
			//vnitrni tlacitka
			svetla(1);
			kontrolaVnitrnichTlacitek = 1;
		}
		else {
			//vnejsi tlacitka
			svetla(0);
			kontrolaVnitrnichTlacitek = 0;
		}

		//Vstup

		if(kontrolaVnitrnichTlacitek == 0) {
			stisknuteTlactiko = kontrolaVstupuVnejsi();
		}
		else {
			stisknuteTlactiko = kontrolaVstupuVnitrni();
		}

		if(stisknuteTlactiko != 0) {
			if(kontrolaDveri() == 0) {
				printf("Zavrete dvere.\n");
				while(kontrolaDveri() == 0);
			}

			cilovePatro = stisknuteTlactiko;

			if(aktualniPatro > cilovePatro) {
				prepnoutLED(0);
				startPohybu(0);
			}
			else if (aktualniPatro < cilovePatro) {
				prepnoutLED(1);
				startPohybu(1);
			}
			else {
				prepnoutLED(-1);
				stopPohybu();
				continue;
			}

			while(cilovePatro != aktualniPatro) {

				int patro = kontrolaPater();
				if(patro != 0) {
					zobrazitPatro(patro);
				}

				if(kontrolaDveri() == 0) {
					stopPohybu();
					prepnoutLED(-1);
					svetla(1);
					printf("Zavrete dvere.\n");
					while(kontrolaDveri() == 0);
					if(osobaUvnitr() == 0) {
					    svetla(0);
					}

					if(aktualniPatro > cilovePatro) {
						prepnoutLED(0);
						startPohybu(0);
					}

					else if (aktualniPatro < cilovePatro) {
						prepnoutLED(1);
						startPohybu(1);
					}
					else {
						prepnoutLED(-1);
						stopPohybu();
						continue;
					}
				}
			}
			prepnoutLED(-1);
			stopPohybu();
		}
	}
}
