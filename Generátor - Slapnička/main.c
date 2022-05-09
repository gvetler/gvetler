#include <AVR/io.h>
#include <util/delay.h>
#include <math.h>


int hranaty1=0;
int hranaty2=0;
double pila2=0;
int sin3=0;

void channels(int hodnota, int channel)//zobrazeni na kanelech
{
	if(channel==1)
	{
	PORTD = hodnota;
	}
	if(channel==2)
	{
	PORTE = hodnota;
	}
}

void obdelnik(int amplituda1,int channel ,int frekvence1,int perioda1)
{
	if(hranaty1<(perioda1/2))
	{
		hranaty1++;
	}
	if(hranaty1==(perioda1/2))
	{
		amplituda1=0;
		hranaty2++;
	}
	if(hranaty1==(perioda1/2)&&hranaty2==(perioda1/2))
	{
		hranaty1=0;
		hranaty2=0;
	}
	channels(amplituda1,channel);
	_delay_ms(frekvence1);
}

void pila(double amplituda2,int channel ,int frekvence2,double periodapila)
{
	channels(pila2,channel);
	double pomer=(amplituda2/periodapila);
	double pomocnapromenna = (pila2+pomer);
	double tohle=round(pomocnapromenna);
	_delay_ms(frekvence2);
	if(pila2<amplituda2)
	{
		if(pila2<1)
		{
			pila2++;
		}
		pila2 = tohle;
	}
	if(pila2>=amplituda2)
	{
		pila2 = 0;
	}
}

void sinusovka(int sinus1,int channel, int frekvence1,int perioda1)//prvni vypocitana hodnota,2 channel ,3 frekvence ,4 délka periody
{
	channels(sinus1,channel);
	_delay_ms(frekvence1);
	if(sin3<perioda1)
	{
		sin3++;
	}
	if(sin3>=perioda1)
	{
		sin3=0;
	}
}

int main(void)
{
	DDRD = 0xFF;			//channel 1
	DDRE = 0xFF;			//channel 2
	int frekvence = 2;		//doba mezi zobrazením
	//int perioda = 500;		//délka funkce na ose X
	int amplituda = 210;	//max je 4.12V, maximalní hodnota na ose Y(použitelná je 3,281V-210)
	int periodasinus = 300;
	int periodapila =400;
	int periodaobdelnik = 600;
	int sinus[periodasinus];//pøedem poèítaná hodnota grafu sinus
	int channelsinus = 1;	//kanál pro sinus
	int channelpila = 2;	//kanál pro pilu
	int channelobdelnik = 2;//kanál pro obdelník
	
	for(int i = 0; i<periodasinus; i++)
	{//vypoèet sinu na periodu
		sinus[i] = (amplituda/2 + sin((2*M_PI/periodasinus) * i) * amplituda/2);
	}
	while(1)
	{
		sinusovka(sinus[sin3],channelsinus,frekvence,periodasinus);
		_delay_us(20);
		pila(amplituda,channelpila,frekvence,periodapila);
		_delay_us(20);
		//obdelnik(amplituda, channelobdelnik ,frekvence,periodaobdelnik);
	}
}
