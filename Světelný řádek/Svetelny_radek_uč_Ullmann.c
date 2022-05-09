#define F_CPU 14745600UL						// Frekvence krystalu 
#include<stdio.h>
#include<avr/io.h>							// Definice adres portu atd...
#include<avr/interrupt.h>
#include<util/delay.h>

volatile unsigned long NIVO_mil=0;					// Promenna pouzita v prerusovacim programu musi byt VOLATILE protoze by jeji hodnota mohla byt poskozena pri volani preruseni
volatile int NIVO_sec=0;
volatile int NIVO_min=15;
volatile int NIVO_hrs=13;


ISR (TIMER0_OVF_vect)
  {
    NIVO_mil++;
    if (NIVO_mil%1500==0) NIVO_sec++;					// Kalibrace jedne sekundy
    if (NIVO_sec>59) {NIVO_sec=0; NIVO_min++;}
    if (NIVO_min>59) {NIVO_min=0; NIVO_hrs++;}
    if (NIVO_hrs>23) {NIVO_hrs=0; NIVO_min=0; NIVO_sec=0; NIVO_mil=0;}
  }

void NIVO_rt_init (void)
  {
    TCCR0=0x03;  // Citac v normalni rezimu s preddelicem 3, t.j. 256 ??
    TIMSK=0x01;  // Povoleni preruseni od preteceni citace 0 (generuje zakladni signal a vola preruseni)
    sei();       // Sei znamena, ze preruseni zapneme. cli() by bylo pro vypnuti
  }

//////////////////////////////////////////////////
//
// Light news row
//
//////////////////////////////////////////////////

uint8_t decoder[10][8] = { 0xFF,0x81,0x81,0x81,0x81,0xFF,0x00,0x00,
                           0x00,0x00,0x00,0x00,0x00,0xFF,0x00,0x00,
                           0x8F,0x89,0x89,0x89,0x89,0xF1,0x00,0x00,
                           0x89,0x89,0x89,0x89,0x89,0xFF,0x00,0x00,
                           0xF0,0x08,0x08,0x08,0x08,0xFF,0x00,0x00,
                           0xF1,0x89,0x89,0x89,0x89,0x8F,0x00,0x00,
                           0xFF,0x89,0x89,0x89,0x89,0x8F,0x00,0x00,
                           0x80,0x80,0x80,0x80,0x80,0xFF,0x00,0x00,
                           0xFF,0x89,0x89,0x89,0x89,0xFF,0x00,0x00,
                           0xF1,0x89,0x89,0x89,0x89,0xFF,0x00,0x00 };


#define _S_DELAY 25                  //Kratke zpozdeni v mikrosekundach (nutno vyladit)
#define _L_DELAY 1150                 //Dlouhe zpozdeni v mikrosekundach (nutno vyladit)
                           
void hw_init(void)
  {
    DDRD=0xFF;
    DDRB=0xFF;
  }

void pulse_reg (uint8_t reg)
  {
     uint8_t Foo=(1 << reg);     // Vyber registru pro zapis
     PORTB=Foo;			 // Impuls pro zapsani
     _delay_us(_S_DELAY);        // pockat
     PORTB=0x00;                 // vypnout
     _delay_us(_S_DELAY);

  }


void draw_column (uint8_t col,uint8_t a,uint8_t b, uint8_t c, uint8_t d, uint8_t e, uint8_t f)
  {
    PORTD=0xFF;						// FF do sloupcoveho
    pulse_reg(6);
    _delay_us(_L_DELAY);
    PORTD=decoder[a][7-col]^0xFF;			// Col-ty sloupec do segmentoveho reg. 1
    pulse_reg(0);
    PORTD=decoder[b][7-col]^0xFF;
    if (col==0) PORTD=0x24^0xFF;
    pulse_reg(1);
    PORTD=decoder[c][7-col]^0xFF;
    pulse_reg(2);
    PORTD=decoder[d][7-col]^0xFF;
    if (col==0) PORTD=0x24^0xFF;
    pulse_reg(3);
    PORTD=decoder[e][7-col]^0xFF;
    pulse_reg(4);
    PORTD=(1 << col)^0xFF;
    PORTD=decoder[f][7-col]^0xFF;
    pulse_reg(5);
    PORTD=(1 << col)^0xFF;                            // Vyber sloupce
    pulse_reg(6);                                     // Zapis do sloupcoveho registru
    _delay_us(_L_DELAY);
  }



int main (void)
  {
     uint8_t foo;
     NIVO_rt_init();				// Nastaveni casovace a spusteni prerusovaciho systemu
     hw_init();					// Nastaveni portu na vystup
     while (1) 
       {
          for (foo=0;foo<8;foo++)
            {
              draw_column(foo,NIVO_hrs/10,NIVO_hrs%10,NIVO_min/10,NIVO_min%10,NIVO_sec/10,NIVO_sec%10);  // Behame dokola pres vsech 8 sloupcu a kreslime tak hodiny, ktere bezi na 
            }
       } 
  }