#include <stdio.h>
#include <sys/io.h>
#include "bity.h"
int main(void)
{
    if(ioperm(0x300,2,1)!=0){
	printf("neni pristup k portu 300");
	return 1;
    }
if(ioperm(0x301,2,1)!=0){
	printf("Neni pristup k portu 301");
	return 1;
}
    //pri spusteni do 1 patra 
    
     int opakk = 0;
     while(opakk<5){
        int stavp44=inb(0x301);
        int dvere = bitisClear(stavp44, 5);
        if(dvere==1){
	//int patepatro = bitisClear(stavp44, 4);
	int prvnipatroo =bitisClear(stavp44, 0);
	outb(0b11111100,0x301);
	if(prvnipatroo==1){
		outb(0b11111111, 0x301);
		opakk =5;
	}
}
}
    while(1){
    int motord = 0b11111100;
    int motorn = 0b11111110;
    int opak =0;
    int stavp4 =inb(0x301);
    int nicc = 0b11111111;
    int stavp3=inb(0x300);
    int dvere = bitisClear(stavp4, 5);
    //prvni patro
	int bitnula1c = bitisClear(stavp3, 0);
	int bitnula1v = bitisClear(stavp3,4);
	int prvnipatro = bitisClear(stavp4,0);
	// druhe
	int bitnula2c = bitisClear(stavp3, 1);
	int bitnula2v = bitisClear(stavp3, 5);
	int druhepatro =bitisClear(stavp4, 1);
	//treti
	int bitnula3c = bitisClear(stavp3, 2);
	int bitnula3v = bitisClear(stavp3, 6);
	int tretipatro = bitisClear(stavp4, 2);
	//ctvrte 
	int bitnula4c = bitisClear(stavp3,3);
	int bitnula4v = bitisClear(stavp3,7);
	int ctvrtepatro = bitisClear(stavp4, 3);
	
	//signalizace kabiny
	int rozsvit = 0b11011111;
	int zhasni = 0b11111111;
	int oteverenedvere = bitisSet(stavp4, 5);
	//led
	int ledd= clearBit(rozsvit, 3); //rozsviti v kabine i signalizaci smìru
	int ledn= clearBit(rozsvit,4);
	    if(oteverenedvere==1){
		outb(rozsvit, 0x300);
	    }
	if(dvere==1){		//podminka zavreni dveri
	
	//pohyb do 1 patra
	if(prvnipatro==0){
		if(bitnula1c==1||bitnula1v==1){ //stisknute placitko v kabine nebo venku
			outb(motord,0x301); //dolu
//			outb(rozsvit,0x300); //rozsvit svetlo v kabine
			outb(ledd,0x300);
		}
	}
//		int prvnipatro = bitisClear(stavp4,0);
		if(prvnipatro==1){
			outb(nicc , 0x301);
			if(oteverenedvere==0){
				outb(zhasni,0x300);
			}
		}
}	
	//druhepatro
	if(bitnula2c==1||bitnula2v==1){
		if(druhepatro==0){
			if(stavp4==0x5E||stavp4==0xDE){ //nahoru
				outb(motorn, 0x301);
//				outb(rozsvit,0x300);
				outb(ledn, 0x300);
			}
			if(stavp4==0x5B||stavp4==0xDB||stavp4==0xD7||stavp4==0x57||stavp4==0x4F||stavp4==0xCF){ //dolu
				outb(motord,0x301);
//				outb(rozsvit,0x300);
				outb(ledd, 0x300);
			}
		}
			if(druhepatro==1){  //motor stop
				outb(nicc, 0x301);
				if(oteverenedvere==0){
					outb(zhasni, 0x300);
				}
			}
	}
	//treti patro
	if(bitnula3c==1||bitnula3v==1){
		if(tretipatro==0){
			if(stavp4==0xDD||stavp4==0x5D||stavp4==0xDE||stavp4==0x5E){
				outb(motorn,0x301);
//				outb(rozsvit,0x300);
				outb(ledn, 0x300);
			}
			if(stavp4==0xDB|stavp4==0x5B||stavp4==0x4F||stavp4==0xCF||stavp4==0x57||stavp4==0xD7){
				outb(motord, 0x301);
//				outb(rozsvit,0x300);
				outb(ledd, 0x300);
		}
	}
		if(tretipatro==1){
			outb(nicc,0x301);
			if(oteverenedvere==0){
				outb(zhasni, 0x300);
			}
		}
	}
	//ctvrtepatro
	if(bitnula4c==1||bitnula4v==1){
		if(ctvrtepatro==0){
			if(stavp4==0x5B||stavp4==0xDB||stavp4==0xDD||stavp4==0x5D||stavp4==0xDE||stavp4==0x5E){
				outb(motorn,0x301);
//				outb(rozsvit,0x300);
				outb(ledn, 0x300);
			}
			if(stavp4==0x4F||stavp4==0xCF){
				outb(motord, 0x301);
//				outb(rozsvit,0x300);
				outb(ledd, 0x300);
			}
		}
		if(ctvrtepatro==1){
			outb(nicc,0x301);
		if(oteverenedvere==0){
			outb(zhasni, 0x300);
		}
		}
    }
    
}
}

