#include <AVR/io.h>
#include <util/delay.h>
//zapojeni 1-5 jsou vstupy pro pamet znaku musime zapojit vsechny i kdyz pouzivame jen 4
//7 zavreni dveri (zamceni)
//8.bit pro tlacitko MODE
//9 pro tlacitko sipka nahoru
//10 tlacitko sipka dolu
//11 tlacitko SET
//12 vystup klavesnice
//16 rozsviceni zarovky
//20 zamek odemknout

	int cislo = 0b11100000;								   //počáteční hodnota
	int pozice[5] = {254,253,251,247,239};   //pole pro aktivace pozice, log 0
	int kod[4] = {224,227,230,233};          //kod 3 6 9 na pozici 2 3 4
	int zadanykod[4] = {224, 224, 224, 224}; //kod který byl zadán v tomto případě 0 0 0 0
	int currentpozice = 0;									 //proměnná pro práci s pozicemi
	int maska = 128;												 //10000000

	void zobrazeni_zamceno(int i)//funkce zobrazující číslo na displeji, když je zavřeno
	{
		PORTE = pozice[i];		//nejdříve je nastavena pozice daného čísla
		PORTB = zadanykod[i]; //a poté a do paměti nahrán znak uložený v poly
	    _delay_ms(5);				//zpoždení aby bylo číslo vidět a
	}
	void zobrazeni_open(int i) //funkce zobrazující číslo na displeji, když je otevřeno
	{
		PORTE = pozice[i];	//stejná jako u zamčeného
		PORTB = (kod[i]& ( ~(maska))); //je zobrazován kod pro otevření a k tomu je posílána log 0 na zámek a žárovku
		_delay_ms(5);
	}

void stav_otevreno() 	//když bylo zadáno správné heslo je volán stav_otevreno
{											//tento stav fuguje velice podobně jako main funkce až na pár vyjímek
	int break1 = 0;
	    while(1)
	       {
		for(int i = 0;i<11;)
	  	{
		 if(currentpozice != 0) //zobrazování pro čísla která nejsou momentálě nastavována na currentpozici
		 {
				zobrazeni_open(0);  //zavolána funkce s hodnotou danné pozice
		 }
	  	 if(currentpozice != 1)
		 {
		 		zobrazeni_open(1);
		 }
		 if(currentpozice != 2)
		 {
		 		zobrazeni_open(2);
		 }
		 if(currentpozice != 3)
		 {
		 		zobrazeni_open(3);
		 }
		 PORTE = pozice[currentpozice];//vybraní nastavované pozice a nastavené čísla(hodnota zvolená)
		 PORTB = (cislo & ( ~(maska)));//maska slouží k držení zámku a žárovky v log. 0
		 _delay_ms(5);
		 i++;
		 }

		for(int i = 0;i<4;)//smyčka kontorlující stav tlačítek
		 {
		 PORTE = pozice[i];//aktivace pozice
		 if(i==1 && PINA != (PINA | (1 << 0)))//tlacitko + ....když je nastavená pozice a výstup z
		 {																						//klávensice na log 0, je provedena podmínka
		    cislo++;
		 }
		 if(i==2 && PINA != (PINA | (1 << 0)))// tlacitko -
		 {
		    cislo--;
		 }
		 if(i==0 && PINA != (PINA | (1 << 0)))//tlacitko MODE pro
		 {				      //potvrzeni hesla
				PORTB = cislo;
		 		break1 = 1;//proměnná pro přerušení stavu
		 }
		 if(i==3 && PINA != (PINA | (1 << 0)))    //tlacitko set
		 {				          //pro zmenu pozice
		       	kod[currentpozice] = cislo;       //ukladani zvoleneho cisla do pole kod o indexu currentpozice
		       	currentpozice++;		  //následné posunutí pozice doprava
		 }
		 if(cislo != ((cislo&(~(1<<3))))&&(cislo!=((cislo&(~(1<< 1 ))))))                    		 {
		  	cislo = 0b11100000;                     //nastavení čísla na display do nuly pokud přesáhne hodnotu 9
				PORTB = (cislo & ( ~(maska)));					//zobrazení čísla

		 }
		 if(PINA != (PINA & (~(1 << 1))))//když je 1 bit rozdílný od 0 je maska nastavena do 0
		 {
		 		maska = 0;
		 }
		 if(currentpozice == 4)
		 {
				currentpozice = 0;          //kdyz pozice prekroci 4bit je nulovana
		 }
		 i++;
		  }
		 if(break1 == 1)//přerušení funkce
		 {
		 		break;
		 }
   }
 }


int main()
{
DDRB = 0b11111111;		//display  deklarovaní vstupů a výstupů
DDRE = 0b11111111;		//control
DDRA = 0b11111100;	  //stavy výstupů
		while(1)
		{
		    for(int i = 0;i<11;)		//při tomto zpoždení je idealní opakovat 11 krát. aby byla čísla vidět a neblikala
	 	    {
	        if(currentpozice != 0)	//zobrazování pro čísla která nejsou momentálě nastavována na currentpozici
		      {
		 	  	zobrazeni_zamceno(0);	  //zavolána funkce s hodnotou danné pozice
		      }
		    	if(currentpozice != 1)
		    	{
					zobrazeni_zamceno(1);
		    	}
		     	if(currentpozice != 2)
		     	{
		    		zobrazeni_zamceno(2);
		    	}
		    	if(currentpozice != 3)
		    	{
		    		zobrazeni_zamceno(3);
		    	}
					PORTE = pozice[currentpozice];	//vybraní nastavované pozice a nastavené čísla(hodnota zvolená)
					PORTB = cislo;
					_delay_ms(5);
		    	i++;
		    	}
		    for(int i = 0;i<4;)		//smyčka pro kontrolu stavu tlačítek
		    {
				  PORTE = pozice[i];	//smyčka vyzkouší všechny pozice od 0 do 3 a pokud je výstup z klávensice v log. 0 je provedena podmínka
		          if((i==1) && (PINA != (PINA | (1 << 0))))//tlacitko +
		          {
		          	cislo++;
		          }
		          if((i==2) && (PINA != (PINA | (1 << 0))))// tlacitko -
		          {
		          	cislo--;
		          }
		          if((i==0) && (PINA != (PINA | (1 << 0))))//tlacitko MODE pro
		          {				       //potvrzeni hesla
		      	  	if(zadanykod[0] == kod[0] && zadanykod[1] == kod[1] && zadanykod[2] == kod[2] && zadanykod[3] == kod[3])
		    			{			//porovná námi zadaná čísla s nastavenou hodnotou pole a když se schodují otevře dveře
							PORTB = (cislo & ( ~(160)));	//otevření dveří poslaní log 0 na port 20
							_delay_ms(300);
							stav_otevreno();  //uvedení ovládání do stavu otevřeno
							_delay_ms(300);
		    			}
		          }
		          if((i==3) && (PINA != (PINA | (1 << 0))))    //tlacitko set
		          {				           //pro zmenu pozice
		          	zadanykod[currentpozice] = cislo;  //ukladaní zvoleného čísla do pole o indexu currentpozice a posunutí
								currentpozice++;
								cislo = zadanykod[currentpozice];
		          }
		          if(cislo != ((cislo & (~( 1 << 3 )))) && (cislo != (( cislo & (~( 1 << 1 )))))) //kontrola čísla pomocí porovnávání stavu 3 a 1 bitu
				  	  {		//když jsou oba bity v log 1 je číslo nastaveno do 0(přesáhe hodnotu 9 a zobrazuje znak ')
		    	   	cislo = 0b11100000;         //nastaveni cisla na display do nuly
							PORTB = (cislo);						//zobrazeni nového čísla na výstupu
							_delay_ms(10);
		          }
		    	  	if(currentpozice == 4)
		          {
		      			currentpozice = 0;          //kdyz pozice prekroci 4bit je nulovana
					    	_delay_ms(10);
		          }
		          i++;
		   	}
		}
	}
