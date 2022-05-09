#include <avr/io.h>
#include <util/delay.h>

void init(void) {
	DDRD = 0xFF;
	DDRB = 0xFF;
	PORTD = 0xFF;
	_delay_ms(10);
	PORTB = 0x3F;
	_delay_ms(10);
}

void zapsatDoRegistruMatice(int hodnota, int cisloMatice) { //zapisuje hodnoty ve sloupci
	PORTB = 0;
	PORTD = ~hodnota;
	PORTB = 1<<cisloMatice;
	PORTB = 0;
}

void zapsatDoRegistruSloupce(int cisloSloupce) { //zapisuje hodnoty aktivniho sloupce
	PORTD = ~(1<<cisloSloupce);
	PORTB = 128;
	PORTB = 0;
}

int main(void) {
	init();
		
	int cisla[10][8] = {{0x0, 0x7e, 0xff, 0xd3, 0xcb, 0xff, 0x7e, 0x0}, //vizualizace èísel
						{0x0, 0x1, 0x1, 0xff, 0xff, 0x61, 0x1, 0x0},
						{0x0, 0x62, 0xf3, 0xd3, 0xcb, 0xcf, 0x66, 0x0},
						{0x0, 0x6e, 0xff, 0x99, 0x99, 0xc3, 0x42, 0x0},
						{0x0, 0xc, 0xff, 0xff, 0x4c, 0x2c, 0x1c, 0x0},
						{0x0, 0xe, 0x9f, 0x91, 0x91, 0xf3, 0x72, 0x0},
						{0x0, 0x4e, 0x9f, 0x91, 0x91, 0xff, 0x7e, 0x0},
						{0x0, 0xe0, 0xf0, 0x9f, 0x8f, 0xc0, 0xc0, 0x0},
						{0x0, 0x6e, 0xff, 0x91, 0x91, 0xff, 0x6e, 0x0},
						{0x0, 0x7e, 0xff, 0x89, 0x89, 0xf9, 0x72, 0x0}};
	
	//pøesný èas
	int hodiny = 12;
	int minuty = 38;
	int vteriny = 35;
	
	while(1) { 
		
		int i;
		int j;
		int k;
		for (k = 0; k<120; k++){ //timer
			for (i = 0; i<8; i++) { //èísla
				for (j = 0; j<6; j++) { //matice
			
					int cisloKZobrazeni;
					switch (j) {
				
					case 0:
						cisloKZobrazeni = hodiny/10;
						break;
					case 1:
						cisloKZobrazeni = hodiny%10;
						break;
					case 2:
						cisloKZobrazeni = minuty/10;
						break;
					case 3:
						cisloKZobrazeni = minuty%10;
						break;
					case 4:
						cisloKZobrazeni = vteriny/10;
						break;
					case 5:
						cisloKZobrazeni = vteriny%10;
						break;
					}
				zapsatDoRegistruMatice(cisla[cisloKZobrazeni][i], j);
				zapsatDoRegistruSloupce(i);
				
				}
			_delay_ms(1);
			}
		}
		
		vteriny++;
					if(vteriny > 59) {
						minuty++;
						vteriny = 0;
						if(minuty > 59) {
							minuty = 0;
							hodiny++;
						if(hodiny > 23) {
							hodiny = 0;
							minuty = 0;
							vteriny = 0;
					}
				}
			}
	}
		
	return 1;
}