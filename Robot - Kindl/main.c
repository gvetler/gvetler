#include <stdio.h>
#include <sys/io.h>
#include "bity.h" //bitová knihovna
#include <time.h>

int vych(void) //vychozi pozice
{
	struct timespec t;
	t.tv_sec = 0;
	t.tv_nsec = 2500000;
	struct timespec t2;
	t2.tv_sec=1;
	t2.tv_nsec = 0;
	int j;
	for(j=0;j<1200;j++) //počet kroků k nalezení výchozí pozice základny pokud začínáme úplně vlevo
	{
	int p4 = inb(0x301);
	int irz = bitisClear(p4,1);
		outb(0b11011101,0x301);
		nanosleep(&t,NULL);
		outb(0b11111101,0x301);
		if(irz == 1)
		{
			return 1; //ukončení funkce
		}
	}
	int c;
	for(c=0;c<2800;c++) //počet kroků k nalezení výchozí pozice základny pokud začínáme úplně vpravo
	{
	int p44 = inb(0x301);
	int irzz = bitisClear(p44,1);
		outb(0b11001101,0x301);
		nanosleep(&t,NULL);
		outb(0b11101101,0x301);
		if(irzz==1)
		{
			return 1;
		}
	}
}

int main(void)
{
	//definovaní časových zpoždění

	struct timespec t;
	struct timespec t2;
	t.tv_sec = 0;
	t.tv_nsec = 2500000;
	t2.tv_sec = 1;
	t2.tv_nsec = 0;
	
	//pristup k portum

	if(ioperm(0x300,2,1)!=0){
		printf("neni pristup k portum 0x300");
		return 1;
	}
	if(ioperm(0x301,2,1)!=0){
		("neni pristup k portum 0x301");
		return 1;
	}
	vych(); //vychozí pozice
	int i = 1;
while(1){ //hlavní cyklus 
	while(i==1){ //podmineny cyklus
	int p4 = inb(0x301); //čtení z portu
	printf("hodnota p4 =%d ", p4);
		int p3 = inb(0x300);
		
		int pravetl = bitisClear(p3,0); //zmacknute prave tl.
		int dolutl = bitisClear(p3,2); 	//zmacknute dolu tl.
		int nahorutl = bitisClear(p3,3);//zmacknute nahoru tl.
		int levetl = bitisClear(p3,1); //zmacknute leve tl.
		int tl = bitisClear(p3,4);     //zmacknute tlacitko hlavní
		int p33 = 0x301;
		
		if(pravetl ==1) //pohyb zaklady doprava
		{
//			printf("jedu doprava");
			outb(0b11011101,p33);
			nanosleep(&t,NULL);
			outb(0b11111101,p33);
		}
		else
		if(levetl==1) //pohyb zaklady doleva
		{
//			printf("jedu doleva");
			outb(0b11001101,p33);
			nanosleep(&t,NULL);
			outb(0b11101101,p33);
		}
		else
		if(dolutl ==1) //hl. rameno dolu
		{
//			printf("jedu dolu");
			outb(0b11011110,p33);
			nanosleep(&t,NULL);
			outb(0b11111110,p33);
		}
		else
		if(nahorutl ==1) //hl. rameno nahoru
		{
//			printf("jedu nahoru");
			outb(0b11001110,p33);
			nanosleep(&t,NULL);
			outb(0b11101110,p33);
		}
		else
		if(tl ==1) //zmacknute tlacitko
		{ 
		 i = 2;
		 nanosleep(&t2,NULL);
		}
	}
	while(i==2) //ovladani ramena s chapadlem
	{
	int p4 = inb(0x301);
	printf("hodnota p4 = %d", p4);
	int p3 = inb(0x300);
	int p33 = 0x301;
	int nahorutl = bitisClear(p3,3);
	int dolutl = bitisClear(p3,2);
	int tl = bitisClear(p3,4);
//	outb(0b11111111,p33);
		if(nahorutl==1) //rameno nahoru
		{
//			printf("chapadlo nahoru");
			outb(0b11011011,p33);
			nanosleep(&t,NULL);
			outb(0b11111011,p33);
		}
		else
		if(dolutl ==1) //rameno dolu
		{
//			printf("chapadlo dolu");
			outb(0b11001011,p33);
			nanosleep(&t,NULL);
			outb(0b11101011,p33);
		}
		else 
		if(tl==1)
		{
		i = 3;
		nanosleep(&t2,NULL);
		}
	}
	while(i==3) //ovladani chapadla
	{
		int p4 = inb(0x301);
		printf("hodnota i = %d",p4);
		int p3 = inb(0x300);
		//zavrit
		int nahorutl = bitisClear(p3,3);
		//otevrit
		int dolutl =bitisClear(p3,2);
		int p33 = 0x301;
		int tl = bitisClear(p3,4);
		
		if(nahorutl==1) //chapadlo zavřít
		{
			outb(0b11010111,p33);
			nanosleep(&t,NULL);
			outb(0b11110111,p33);
		}
		else
		if(dolutl==1) //chapadlo otevřít
		{
			outb(0b11000111,p33);
			nanosleep(&t,NULL);
			outb(0b11100111,p33);
		}
		else 
		if(tl==1) //zmačknuté tlačítko
		{
			i=1; //zpět na ovladani zakladny
			nanosleep(&t2,NULL);
		}
	}
}
}