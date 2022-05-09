#include <avr/io.h>
#include <util/delay.h>

int stavPortuB = 0xFF;
int zvolenyBit = 0;
int pocetProbehnutychCyklu = 0;
int zvolenaCisla[4];

int zadaneHeslo[4];

int stisknuteTlacitkoNahoru = 0;
int stisknuteTlacitkoDolu = 0;
int stavTlacitkaMode = 0;

int zamceno = 0;

void init() {
	DDRD = 0xFF;
	DDRB = (~(1<<4)) & (~(1<<6));
	PORTD = 0xFF;
	PORTB = stavPortuB;
}

int zapnoutBit(int stavPortu, int cisloBitu) {
	return (stavPortu | (1<< cisloBitu));
}
int vypnoutBit(int stavPortu, int cisloBitu) {
	return (stavPortu & (~(1<<cisloBitu)));
}

void nastaveniHesla() {
	int nastavovaniKodu = 1;
	while(nastavovaniKodu == 1) {
		
		//Cyklus pro cykleni mezi jednotlivymi misty cisla
		for(int i = 0; i<4; i++) {
			
			//Efekt blikani pro zvolene cislo
			if((i == zvolenyBit) && (pocetProbehnutychCyklu < 150)) PORTD = (29 | (~31)); //Nahrani cisla do mezipameti
			
			//Standardni efekt
			else PORTD = (zvolenaCisla[i] | (~31)); //Nahrani cisla do mezipameti
			
			stavPortuB = vypnoutBit(stavPortuB, i);
			
			PORTB = stavPortuB; //Nahrani cisla z mezipameti na vhodne misto
			_delay_us(1);
			
			if(((PINB & (1<<4)) == 0))
			{
				switch(i)
				{
					case 0:
						stavTlacitkaMode = 1;
					break;
					case 1:
						stisknuteTlacitkoNahoru = 1;
					break;
					case 2:
						stisknuteTlacitkoDolu = 1;
					break;
					case 3:
						nastavovaniKodu = 0;
					break;
				}
			}
			
			else if((stavTlacitkaMode == 1) && (i == 0))
			{
				stavTlacitkaMode = 0;
				zvolenyBit++;
				zvolenyBit = zvolenyBit%4;	
			}
			
			else if ((stisknuteTlacitkoNahoru == 1) && (i == 1))
			{
				++zvolenaCisla[zvolenyBit];
				zvolenaCisla[zvolenyBit] = zvolenaCisla[zvolenyBit]%10;
				stisknuteTlacitkoNahoru = 0;
			}
	
			else if((stisknuteTlacitkoDolu == 1) && (i == 2))
			{
				--zvolenaCisla[zvolenyBit];
				zvolenaCisla[zvolenyBit] = (zvolenaCisla[zvolenyBit]+10)%10;
				stisknuteTlacitkoDolu = 0;
			}
			
			_delay_ms(1);
			stavPortuB = zapnoutBit(stavPortuB, i);
			PORTB = stavPortuB;
		}
		if(pocetProbehnutychCyklu == 300) pocetProbehnutychCyklu = 0;
		pocetProbehnutychCyklu++;
	}
	zvolenyBit = 0;
}

void zadaniHesla() {
	int nastavovaniKodu = 1;
	while(nastavovaniKodu == 1) {
		
		//Cyklus pro cykleni mezi jednotlivymi misty cisla
		for(int i = 0; i<4; i++) {
			
			//Efekt blikani pro zvolene cislo
			if((i == zvolenyBit) && (pocetProbehnutychCyklu < 150)) PORTD = (29 | (~31)); //Nahrani cisla do mezipameti
			
			//Standardni efekt
			else PORTD = (zadaneHeslo[i] | (~31)); //Nahrani cisla do mezipameti
			
			stavPortuB = vypnoutBit(stavPortuB, i);
			
			PORTB = stavPortuB; //Nahrani cisla z mezipameti na vhodne misto
			_delay_us(1);
			
			if(((PINB & (1<<4)) == 0))
			{
				switch(i)
				{
					case 0:
						stavTlacitkaMode = 1;
					break;
					case 1:
						stisknuteTlacitkoNahoru = 1;
					break;
					case 2:
						stisknuteTlacitkoDolu = 1;
					break;
					case 3:
						nastavovaniKodu = 0;
					break;
				}
			}
			
			else if((stavTlacitkaMode == 1) && (i == 0))
			{
				stavTlacitkaMode = 0;
				zvolenyBit++;
				zvolenyBit = zvolenyBit%4;	
			}
			
			else if ((stisknuteTlacitkoNahoru == 1) && (i == 1))
			{
				++zadaneHeslo[zvolenyBit];
				zadaneHeslo[zvolenyBit] = zadaneHeslo[zvolenyBit]%10;
				stisknuteTlacitkoNahoru = 0;
			}
	
			else if((stisknuteTlacitkoDolu == 1) && (i == 2))
			{
				--zadaneHeslo[zvolenyBit];
				zadaneHeslo[zvolenyBit] = (zadaneHeslo[zvolenyBit]+10)%10;
				stisknuteTlacitkoDolu = 0;
			}
			
			_delay_ms(1);
			stavPortuB = zapnoutBit(stavPortuB, i);
			PORTB = stavPortuB;
		}
		if(pocetProbehnutychCyklu == 300) pocetProbehnutychCyklu = 0;
		pocetProbehnutychCyklu++;
	}
	zvolenyBit = 0;
}

int dvereZavrene() {
	if((PINB&(1<<6)) == 0) return 1;
	return 0;
}

void zarovka(int vypnout) {
	if(vypnout == 1) stavPortuB = zapnoutBit(stavPortuB, 5);
	else stavPortuB = vypnoutBit(stavPortuB, 5);
	
	PORTB = stavPortuB; 
}

int spravneHeslo() {
	for(int i = 0; i<4; i++) {
		if(zadaneHeslo[i] != zvolenaCisla[i]) return 0;
	}
	return 1;
}

void otevritDvere() {
	stavPortuB = vypnoutBit(stavPortuB, 7);
	PORTB = stavPortuB;
	_delay_ms(500);
	stavPortuB = zapnoutBit(stavPortuB, 7);
	PORTB = stavPortuB;
	_delay_ms(500);
}


int main() {
	init();
	
	/*
	PORTB = (~(1<<0));
	
	for(int i = 0; i<32; i++) {
		PORTD = i | (~31);
		_delay_ms(500);
	}
	*/
	
	
	while(1) {
	
		zadaneHeslo[0] = 0;
		zadaneHeslo[1] = 0;
		zadaneHeslo[2] = 0;
		zadaneHeslo[3] = 0;
		
		zvolenaCisla[0] = 0;
		zvolenaCisla[1] = 0;
		zvolenaCisla[2] = 0;
		zvolenaCisla[3] = 0;
		
		if(dvereZavrene()) otevritDvere();
		zarovka(0);
		
		while(!dvereZavrene());
		zarovka(1);
		
		nastaveniHesla();
		
		_delay_ms(2000);
		
		zadaniHesla();
		
		while(spravneHeslo() != 1) {
			_delay_ms(500);
			
			int text[] = { 14, 23, 23, 0 };
			
			for(int j = 0; j<500; j++) {
				for(int i = 0; i<4; i++) {
					PORTD = (text[i] | (~31)); //Nahrani cisla do mezipameti
					stavPortuB = vypnoutBit(stavPortuB, i);		
					PORTB = stavPortuB; //Nahrani cisla z mezipameti na vhodne misto
					_delay_ms(1);
					stavPortuB = zapnoutBit(stavPortuB, i);
					PORTB = stavPortuB;
				}
			}
			zadaniHesla();
		}
	}
	
	
	return 1;
}