#include <stdio.h>
#include "sim_io.c"
#include <time.h>

//motor aktivni log0
//max kmitocet 450hz 
//P2 b0-3 vyber casti b4 smer a b5 CLK
//P3 stav infradiod(0zakladna, 1 hl.rameno, 2 vl.rameno, 3 chapadlo)
//P4 pro ovladac 0b pravo, 1 levo, 2 dolu, 3 nahoru, 4 attack
//takt vychazi na 2.22ms

void zpozdeni(int sekundy,int nanosekundy)
{	//nastaveni zpozdeni pomoci nanosleep pro s a ns
struct timespec t;
t.tv_sec = sekundy;
t.tv_nsec = nanosekundy;
nanosleep(&t,NULL);
}

/*FILE *fptr;
fptr = fopen("stavy.txt","w+");*/

void CLK(int x)
{
	if(x==1)
	{
	outb(0b11011111,0x301);
	zpozdeni(0,2420000);
	}
	if(x==0)
	{
	outb(0b11001111,0x301);
	zpozdeni(0,2420000);
	}
}


int main()
{
    ioperm(0x301,2,1);
    ioperm(0x300,2,1);
    int promen = 0;
    while(1)
    {
    int stav1 = inb(0x300);
    if(stav1 != (stav1 & (~(1 << 0))))
    {
    	if(promen>=260)
    	{
 	for(int i=0;i<5;i++)
	{
		outb(0b11101110,0x301);
		zpozdeni(0,2420000);
		CLK(0);
	}
    	}
    	if(promen<260)
    	{
	for(int i=0;i<5;i++)
	{
		outb(0b11111110,0x301);
		zpozdeni(0,2420000);
		CLK(1);
	}
	}
    }
  
    if(stav1 != (stav1 & (~(1 << 1))))
    {
	for(int i=0;i<5;i++)
	{
		outb(0b11111101,0x301);
		zpozdeni(0,2420000);
		CLK(1);
	}
    }
    
    if(stav1 != (stav1 & (~(1 << 2))))
    {
	for(int i=0;i<5;i++)
	{
		outb(0b11101011,0x301);
		zpozdeni(0,2420000);
		CLK(0);
	}
    }
    
    if(stav1 != (stav1 & (~(1 << 3))))
    {
	for(int i=0;i<5;i++)
	{
		outb(0b11100111,0x301);
		zpozdeni(0,2420000);
		CLK(0);
	}
    }
    
    if((stav1 != (stav1 | (1 << 0))) && (stav1 != (stav1 | (1 << 1))) && (stav1 != (stav1 | (1 << 2))) && (stav1 != (stav1 | (1 << 3))))
    {
    	break;
    }
    promen++;
    }
    
    
    while(1)
    {
    int stav2 = inb(0x301);
    if(stav2 !=( stav2 & (~(1<<4))))//kdyz neni aktivni tlacitko attack
    {
    	if((stav2 != (stav2 | (1 << 0))))//podminka pro 
    	{		//tlacitko do prava zakladny
    		outb(0b11111110,0x301);
    		zpozdeni(0,2420000);
    		CLK(1);
    	}
    	if((stav2 != (stav2 | (1 << 1))))//podminka pro 
    	{		//tlacitko do leva zakladny
    		outb(0b11101110,0x301);
    		zpozdeni(0,2420000);
    		CLK(0);
    	}
    	if((stav2 != (stav2 | (1 << 2))))//podminka pro 
    	{		//tlacitko dolu hl.ramena
    		outb(0b11111101,0x301);
    		zpozdeni(0,2420000);
    		CLK(1);
    	}
    	if((stav2 != (stav2 | (1 << 3))))//podminka pro
    	    	{		//tlacitko nahoru hl.ramena 
    		outb(0b11101101,0x301);
    		zpozdeni(0,2420000);
    		CLK(0);
    	}
    }
    
    
    //kdyz je tlacitko attack stisknuto
    if(stav2 != ( stav2 | (1<<4)))
    {
    	if((stav2 != (stav2 | (1 << 0))))//podminka pro 
    	{	//tlacitko dolu vl.ramena
    		outb(0b11111011,0x301);
    		zpozdeni(0,2420000);
    		CLK(1);
    	}
    	if((stav2 != (stav2 | (1 << 1))))//podminka pro 
    	{	//tlacitko dolu vl.ramena
    		outb(0b11101011,0x301);
    		zpozdeni(0,2420000);
    		CLK(0);
    	}
    	if((stav2 != (stav2 | (1 << 2))))//podminka pro 
    	{	//tlacitko dolu chapadla
    		outb(0b11110111,0x301);
    		zpozdeni(0,2420000);
    		CLK(1);
    	}
    	if((stav2 != (stav2 | (1 << 3))))//podminka pro 
    	{	//tlacitko nahoru chapadla
    		outb(0b11100111,0x301);
    		zpozdeni(0,2420000);
    		CLK(0);
    	}
    }   
  }
}
