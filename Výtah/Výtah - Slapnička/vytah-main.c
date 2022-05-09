#include <stdio.h>
#include "sim_io.h"
#include <time.h>

/*P1  b0-2 7segmentovy displ.(111=7,110=6) b3 LED down, b4 LED up b5 cabin light b6 signal
P2 b0 motor start b1 smer 
P3 b0-3 cabin buttons(jen 4) b4-7 floor buttons
P4 b0-4 senzory pater b5 senzor dveri b6 senzor podlahy 
b7 snimac pohybu hridle
*/
int preruseni=0;
int stavP1 = 255;
int patro = 1;
int patro_request = 1;

void zpozdeni(int sekundy,int nanosekundy)
{ 	//nastaveni zpozdeni pomoci nanosleep pro s a ns
struct timespec t;
t.tv_sec = sekundy;
t.tv_nsec = nanosekundy;
nanosleep(&t,NULL);
}

void pohyb(int smer)//fce pro pohyb vytahu(0-dolu, 1-nahoru)
{
	int stav1=inb(0x301);
	if(smer==0)
	{//smer dolu
		outb(0b11111100,0x301);
		stavP1 = (stavP1 & (~(1<<3)));//LED down
		stavP1 = (stavP1 | (1<<4));
		outb(stavP1,0x300);
		//zpozdeni(0,100000);
	}
	if(smer==1)
	{//smer nahoru
		outb(0b11111110,0x301);
		stavP1 = (stavP1 & (~(1<<4)));//LED up
		stavP1 = (stavP1 | (1<<3));
		outb(stavP1,0x300);
		//zpozdeni(0,100000);
	}
	if(stav1 != (stav1 &(~(1<<5))))//pri otevreni dveri zastavi
	{
	outb(255,0x301);
	zpozdeni(2,0);
	}
	zpozdeni(0,100000);
}

void nalezeniprizemi()
{
	int stav1 = inb(0x301);
	if((stav1 != (~(stav1|(1<<0))) && (stav1!=(stav1|(1<<5)))))
	{//kdyz neni snimac 1 patra aktivni a vytah ma zavrene dvere
	pohyb(0);
	}
	if(stav1 != (stav1 | (1<<0)))//kdyz je v 1 patre
	{
	preruseni=1;
	outb(255,0x301);
	}
	if(stav1 != (stav1 &(~(1<<5))))//pri otevreni dveri zastavi
	{
	outb(255,0x301);
	zpozdeni(0,100000);
	}
}

void obsazeni()
{//fce pro zjisteni obsazeni kabiny(je svetlo sviti, neni nesviti)
	int stav1 = inb(0x301);
	if(stav1 != (stav1 |(1<<6)))//6bit floor sensor
	{
	    stavP1 = (stavP1 &(~(1<<5)));//zmena 5 bitu p1 do 0(aktivace)
	    outb(stavP1,0x300);
	    zpozdeni(0,100000);
	}
	if(stav1 != (stav1 &(~(1<<6))))
	{//deaktivace kdyz neni sensor aktivni
	    stavP1 = (stavP1 | (1<<5));
	    outb(stavP1,0x300);
	    zpozdeni(0,100000);
	}
}

void stavtlacitek()
{//fce pro detekci tlacitek
    int stav1=inb(0x300);
    for(int i=0;i<4;i++)
    {
    if(stav1!=(stav1|(1<<i)))//vnitrni btn
    {
    	patro_request = (i+1);
    }
    }
    for(int i=4;i<8;i++)
    {
    if(stav1!=(stav1|(1<<i)))//vnitrni btn
    {
    	patro_request = (i-3);
    }
    }
}

void stav_vytahu()
{
    int stav1 = inb(0x301);
    for(int i=0;i<4;i++)
    {
    if(stav1 != (stav1 | (1<<i)))
    {
    	patro = (i+1);
    }
    }
    if(stav1 != (stav1 &(~(1<<5))))//pri otevreni dveri zastavi
    {
    outb(255,0x301);
    zpozdeni(0,100000);
    }
}

void predpohyb()
{
    int iksko=1;
    if(patro<patro_request)
    {//jede nahoru dokud se nerovnaji
    	pohyb(1);
    	iksko=1;
    }
    if(patro>patro_request)
    {//jede dolu dokud se nerovnaji
    	pohyb(0);
    	iksko=1;
    }
    if(patro==patro_request)//nulovani LED sipek pri zastaveni
    {
    	stavP1=(stavP1|(3<<3));//vymazani sipek pohybu
    	outb(stavP1,0x300);
    	iksko=0;
    }
    if(iksko==0)
    {
        stavP1=(stavP1&(~(1<<6)));//aktivace zvonku
        outb(stavP1,0x300);
    	zpozdeni(0,500000000);//zpozdeni 0.5s
    	stavP1=(stavP1|(1<<6));//deaktivace zvonku
    	outb(stavP1,0x300);
    	iksko=1;
    }
}
void ledpatro()
{
	    int pismenko[4]={6,5,4,3};
	    stavP1 = (stavP1 & (~(pismenko[patro-1]<<0)));
	    outb(stavP1,0x300);
	    zpozdeni(0,1000000);
}

void zvonek()
{
	    
}
void main()
{
	ioperm(0x300,2,1);
	ioperm(0x301,2,1);
	outb(255,0x301);
	outb(255,0x300);
	while(1)
	{//zacatek programu nalezeni prizemi
	    nalezeniprizemi();
	    obsazeni();
	    if(preruseni==1)
	    {
		preruseni=0;
		break;
	    }
	}
	while(1)
	{//hlavni smycka
	    int stav1 = inb(0x300);
	    int stav2 = inb(0x301);
	    for(int i = 0;i<55;i++)//smycka aby to nebylo moc rychle
	    {
	    stavtlacitek();
	    stav_vytahu();
	    predpohyb();
	    obsazeni();
	    ledpatro();
	    zvonek();
	    }
	    outb(255,0x301);
	    stavP1 = (stavP1 |(7<<0));
	    outb(stavP1,0x300);
	}
}
