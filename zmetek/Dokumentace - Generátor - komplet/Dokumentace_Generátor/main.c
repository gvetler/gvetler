#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>
#include <math.h>

//Maximalni amplituda je 219
//Maximalni pocetVzorku je 255

int pocetVzorku1 = 255;
int pocetVzorku2 = 255;

int signalKanalu1[255];
int signalKanalu2[255];

void init(void) {
	DDRB = 0xFF;
	DDRE = 0xFF;
	
	//Pocet vzorku musi byt sudy, aby se dobre pocital trojuhelnik
	//Bez toho by to slo taky, ale program by byl mnohem vic casove narocny
}
void sinusovySignal(int cisloKanalu, int amplituda) {
	int i;
	
	if(cisloKanalu < 0 ||cisloKanalu > 2) {
		printf("Tento kanal nelze zvolit, na vyber jsou pouze kanaly 1,2 \n");
		return;
	}
	
	switch (cisloKanalu) {
		case 1:
			for(i = 0; i<pocetVzorku1; i++) {
				signalKanalu1[i] = (amplituda/2 + sin((2*M_PI/pocetVzorku1) * i) * amplituda/2);
			}
		break;
		case 2:
		for(i = 0; i<pocetVzorku2; i++) {
			signalKanalu2[i] = (amplituda/2 + sin((2*M_PI/pocetVzorku2) * i) * amplituda/2);
		}
		break;
	}
}

void obdelnikovySignal(int cisloKanalu, int amplituda) {
	int i;
	int polovinaVzorkuObdelniku = 255/2;
	
	if(cisloKanalu < 0 ||cisloKanalu > 2) {
		printf("Tento kanal nelze zvolit, na vyber jsou pouze kanaly 1,2 \n");
		return;
	}
	
	for(i = 0; i<polovinaVzorkuObdelniku; i++){
		switch (cisloKanalu) {
			case 1:
				signalKanalu1[i] = 0;
			break;
			case 2:
				signalKanalu2[i] = 0;
			break;
		}
	}
	
	for(i = 0; i<polovinaVzorkuObdelniku; i++){
		switch (cisloKanalu) {
			case 1:
				signalKanalu1[polovinaVzorkuObdelniku + i] = amplituda;
			break;
			case 2:
				signalKanalu2[polovinaVzorkuObdelniku + i] = amplituda;
			break;
		}
	}
}

void trojuhelnikovySignal(int cisloKanalu, int amplituda) {

	if(cisloKanalu < 0 ||cisloKanalu > 2) {
		printf("Tento kanal nelze zvolit, na vyber jsou pouze kanaly 1,2 \n");
		return;
	}
	
	int polovinaVzorkuTrojuhelnik = 255/2;
	
	int i;
	for(i = 0; i<polovinaVzorkuTrojuhelnik; i++) {
		switch (cisloKanalu) {
			case 1:
				signalKanalu1[i] = (amplituda * i)/polovinaVzorkuTrojuhelnik;
			break;
			case 2:
				signalKanalu2[i] = (amplituda * i)/polovinaVzorkuTrojuhelnik;
			break;
		}
	}
	
	for(i = 0; i<polovinaVzorkuTrojuhelnik; i++) {
		
		switch (cisloKanalu) {
			case 1:
				signalKanalu1[polovinaVzorkuTrojuhelnik + i] = amplituda * (polovinaVzorkuTrojuhelnik-i)/polovinaVzorkuTrojuhelnik;
			break;
			case 2:
				signalKanalu2[polovinaVzorkuTrojuhelnik + i] = amplituda * (polovinaVzorkuTrojuhelnik-i)/polovinaVzorkuTrojuhelnik;
			break;
		}
	}
}

void aktivaceSignalu(int frekvence1, int frekvence2) {
	int i;
	
	int aktualniVzorek1 = 0;
	int aktualniVzorek2 = 0;
	
	double mezivypocet1 = 1.0/((double)(frekvence1)*(double)(pocetVzorku1));
	mezivypocet1 = (mezivypocet1/3.4) * 1000000.0;
	int casMeziBody1 = lround(mezivypocet1);

	//Nasobeni 1000000 - prevod na mikrosekundy, deleni 3.4 - upresneni kvuli tomu, ze avr trva chvili zhodnoceni podminek, cimz se snizuje fekvence
	double mezivypocet2 = 1.0/((double)(frekvence2)*(double)(pocetVzorku2));
	mezivypocet2 = (mezivypocet2/3.4) * 1000000.0;
	int casMeziBody2 = lround(mezivypocet2);
	
	int pocetKolikratOpakovat1 = casMeziBody1/1;
	int pocetKolikratOpakovat2 = casMeziBody2/1;
	
	int pocetOpakovani1 = 0;
	int pocetOpakovani2 = 0;
	
	while(1) {
		PORTB = signalKanalu1[aktualniVzorek1];
		PORTE = signalKanalu2[aktualniVzorek2];
		
		pocetOpakovani1++;
		pocetOpakovani2++;
		
		if(pocetOpakovani1 == pocetKolikratOpakovat1) {
			aktualniVzorek1++;
			pocetOpakovani1 = 0;
		}
		
		if(pocetOpakovani2 == pocetKolikratOpakovat2) {
			aktualniVzorek2++;
			pocetOpakovani2 = 0;
		}
		
		if(aktualniVzorek1 == pocetVzorku1) {
			aktualniVzorek1 = 0;
		}
		if(aktualniVzorek2 == pocetVzorku2) {
			aktualniVzorek2 = 0;
		}
		_delay_us(1);
	}
}


int main(void) {
	init();
	sinusovySignal(1, 110);
	sinusovySignal(2, 219);
	//trojuhelnikovySignal(1, 219);
	//obdelnikovySignal(2, 219);
	//obdelnikovySignal(1, 255);
	aktivaceSignalu(4,50);
	return 1;
}