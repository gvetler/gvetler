#include <AVR/io.h>
#include <util/delay.h>

//zadna vystupni data - P1 aktvni v log. 0
//P2 aktivni v log.1
//sloupce matice zacinaji z prava do leva
//radky matice zacinaji dole a konci nahore
//zobrazeni se sklada ze ctyr casti --aktivace C8(column register), vybrani
//sloupce pres P1 data, deaktivace C8 a zapnuti C1-6(matice), a zobrazeni dat pres P1

int matice = 1;
int cas[6] = {2,3,5,9,5,7};	   //ulozena promena pro cas na displaye

int cisla[10][8]={
{0x7c, 0xfe, 0x8a, 0x92, 0xa2, 0xfe, 0x7c, 0x00},
{0x00, 0x02, 0x42, 0xfe, 0xfe, 0x02, 0x02, 0x00},
{0x42, 0xc6, 0x8e, 0x9a, 0x92, 0xf6, 0x66, 0x00},
{0x44, 0xc6, 0x92, 0x92, 0x92, 0xfe, 0x6c, 0x00},
{0x18, 0x38, 0x68, 0xca, 0xfe, 0xfe, 0x0a, 0x00},
{0xf4, 0xf6, 0x92, 0x92, 0x92, 0x9e, 0x0c, 0x00},
{0x3c, 0x7e, 0xd2, 0x92, 0x92, 0x1e, 0x0c, 0x00},
{0xc0, 0xc0, 0x8e, 0x9e, 0xb0, 0xe0, 0xc0, 0x00},
{0x6c, 0xfe, 0x92, 0x92, 0x92, 0xfe, 0x6c, 0x00},
{0x60, 0xf2, 0x92, 0x92, 0x96, 0xfc, 0x78, 0x00}};//2d pole o 10 hodnotach 0-9 o velikosti 8 cisel

int zobrazeni(int promen){
		for(int i=0;i<8;i++)
		{
		   //outb(0xff,matrix_data);
			 PORTE = 0xff;
		   _delay_ms(5);
		   //outb(0x00,matrix_control);
			 PORTA = 0x00;
		   _delay_ms(5);
		   //outb(0b10000000,matrix_control);
			 PORTA = 0b10000000;
		   _delay_ms(5);
		   //outb(~(0b00000001<<i),matrix_data);
			 PORTE = (~(0b00000001<<i));
		   _delay_ms(5);
		   //outb(matice,matrix_control);
			 PORTA = matice;
		   _delay_ms(5);
		   //outb(~(cisla[cas[promen]][7-i]),matrix_data);//je potreba invertovat cislo protoze je aktivni v log. 0
			 PORTE = (~(cisla[cas[promen]][7-i]));
		   _delay_ms(50);
		}
		matice = matice<<1; //od 1. matice do 6.
	}

int main()
{
	DDRE = 0b11111111;	//P1 data
	DDRA = 0b11111111;	//P2 control
	while(1)
	{
		for(int x = 0;x<6;x++){
		zobrazeni(x);
		if(matice == 0b01000000)
		  {
		  matice =1;
		  }
		}
		cas[5] = (cas[5]+1);//pricitani 1s na konci cyklu
		if(cas[5]==10){	    //bude potreba doladit timing
			cas[5]=0;
			cas[4]=cas[4]+1;
			if(cas[4]==6)
			{
			cas[4]=0;
			cas[3]=cas[3]+1;
			    if(cas[3]==10)
			      {
			       cas[3]=0;
			       cas[2]=cas[2]+1;
			        if(cas[2]==6)
			         {
			 	  cas[2]=0;
				  cas[1]=cas[1]+1;
				  	if(cas[1]==10)
					  {
					    cas[1]=0;
					    cas[0]=cas[0]+1;
					  }
					if((cas[0]==2)&&(cas[1]==4))
					  {
					    cas[0]=0;
					    cas[1]=0;
					  }
				  }
			  }
			}
		}
	}
}
