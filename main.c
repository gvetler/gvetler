#include<avr/io.h>
#include<util/delay.h>
#include <math.h>
#include <stdlib.h>
long tobinary(int);
unsigned int sine_value[13] = {128,192,238,255,238,192,128,64,17,0,17,64,128};
int amp = 0XFF;
int amp1 = 255;
int f = 1000/2; // - 1Hz
int f1 = 200; //- 5Hz

void ctverec1(){

	
	 
	while(1){
    PORTB = amp;
	_delay_ms(f);
	PORTB = 0x00;
	_delay_ms(f);
   
}


}
void sinus()
  {
   int i;
	while(1) 
   {
		for(i=0;i<13;i++) 
    {
		PORTB = sine_value[i]; 
		_delay_ms(200); 
	}
	}
  }
  void troju(){
		
   
	while(1)
   {
		int b;
		for(b=0;b<amp1;b++) PORTB = b;
		//_delay_us(0);
		for(b=amp1;b>0;b--) PORTB = b;
		_delay_ms(f1);
   }
 
  
  
  
  }
	
	


int main(void){
//ctverec1();
sinus();
//troju();
	


}



