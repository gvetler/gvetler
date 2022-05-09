#include <AVR/io.h>
#include <util/delay.h>

//data aktivní v log 0 
//control v log 1
//zpozdeni 0.16 seukndu kvuli tomu ze rychlost opakování jednoho sloupce má být 25Hz a máme jich 6 takže celé zpoždìní nám dá dohromady 1ms


int main(void){

DDRB = 0xFF;
DDRD = 0XFF;
int j[8] = {0xFF,0xFF,0xFF,0xDF,0x00,0xFF,0xFF,0xFF};
int d[8] = {0xFF,0xf8,0xba,0x76,0x8e,0xff,0xff,0xff};
int tr[8] = {0xFF,0xFF,0x76,0x76,0x00,0xFF,0xFF,0xFF};
int sedm[8] = {0xFF,0xFF,0x7F,0x77,0x00,0xF7,0xFF,0xFF};
int dvojtecka[8] = {0xff,0xff,0xff,0xbd,0xff,0xff,0xff,0xff};
int sest[8] = {0xff,0xFf,0x00,0x76,0x76,0x70,0xff,0xFf};
int sloupce[8]  ={0x7F,0xBF,0xDF,0xEF,0xF7,0xFB,0xFD,0xFE};
while(1){

for(int i =0 ;i< 8;i++)
{
		PORTB = 0b10000000;
		PORTD = sloupce[i];
		_delay_ms(0.16);
		
		PORTB = 0b00000001;
		PORTD = j[i];
		_delay_ms(0.16);
		
		PORTB = 0b00000010;
		PORTD = d[i];
		_delay_ms(0.16);
		
		PORTB= 0b00000100;
		PORTD = tr[i];
		_delay_ms(0.16);
		
		PORTB = 0b00001000;
		PORTD = sedm[i];
		_delay_ms(0.16);
		
		PORTB = 0b00010000;
		PORTD = dvojtecka[i];
		_delay_ms(0.16);
		
		PORTB = 0b00100000;
		PORTD = sest[i];
		_delay_ms(0.16);
		
}


}







}