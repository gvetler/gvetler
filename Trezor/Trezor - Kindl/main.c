#include  <AVR/io.h>
#include <util/delay.h>


int main(void){

	PORTB= 0b11111111;
	PORTD = 0b11111111;
	DDRE = 0b00000000;
	DDRB = 0b11111111;
	DDRD = 0b11111111;
	int poz1=0b11111110;
	int poz2 =0b11111101;
	int poz3= 0b111111011;
	int poz4 = 0b11110111;
	int c0 = 0b11100000;                 //definice znaku
	int c1 = 0b11100001;
	int c2 = 0b11100010;
	int c3 = 0b11100011;
	int c4 = 0b11100100;
	int c5 = 0b11100101;

	while(1){
	
	if(PINE != (PINE|(1<<3))){ //když jsou otevrene dvere program èeká
	
		for(int i =0;i<4;){ //zobrazovani cisel
			if(i==0){
			PORTB = c1;
			PORTD = poz1;
			_delay_ms(3);
			if(PINE != (PINE|(1<<2))){ //stisknute tlacitko mode
				if((c1==0b11100001) && (c2==0b11100011) && (c3==0b11100011)&& (c4==0b11100100)){ //kod na otevreni 1-3-3-4
				PORTB=0b10000000; //rozsviteni a otevreni
				_delay_ms(5000);
				}
			}
			PORTB = c1; //vypis znaku 1 
			i=1;//nastaveni i
			}
			if(i==1){//plus
			_delay_ms(3);
			PORTB = c2;
			PORTD = poz2;
			_delay_ms(3);
			//int kl1 = PINA;
			if(PINE != (PINE|(1<<2))){
				c2 = 0b11100011;
				
			}
			_delay_ms(3);
			PORTB = c2;
			i=2;
			}
			if(i==2){//minus
			PORTB = c3;
			PORTD = poz3;
			_delay_ms(3);
			if(PINE != (PINE|(1<<2))){
				c3 = 0b11100010;
			}
			_delay_ms(3);
			PORTB = c3;
			i=3;
			}
			if(i==3){//tlacitko set
			_delay_ms(3);
			PORTB = c4;
			PORTD=poz4;
			_delay_ms(3);
			if(PINE != (PINE|(1<<2))){
				poz4=poz1;
				c4 = c3;
				}
			PORTD=poz4;
			PORTB=c4;
			i=0;
			}
		}
	}
	}
}