#include <sys/io.h>
#include <stdio.h>
#include <time.h>

int stavP2;
int ovladaniVpravo;
int ovladaniVlevo;
int ovladaniDolu;
int ovladaniNahoru;
int attackerAktivni;

//IR Zavory
int IROtaceniZakladny;
int IRRamenoChapadla;
int IRHlavniRameno;
int IRChapadlo;

//SmeryOtaceni
int stavOtaceni_0 = 0;
int stavOtaceni_1 = 32;

//Motory
int motorHlavniRameno = 1;
int motorChapadla = 4;
int motorRamenoChapadlo = 8;
int motorOtaceniZakladny = 16;

//pristupovaPrava
int prava = 1;

//Promenne s nahravanim/nacitanim prechozich kroku
int postupovaHodnota = 0;
int spusteneNahravani = 0;
char nazevSouboru[256];

void taktovaniMotoru(void) {
    struct timespec tim;
    tim.tv_sec = 0;
    tim.tv_nsec = 5000000;
    nanosleep(&tim, NULL);
    stavP2 = stavP2 & (~2);
    outb(stavP2, 0x301);
    nanosleep(&tim, NULL);
    stavP2 = stavP2 | (2);
    outb(stavP2, 0x301);
    
}

int vstupAktivni(int vstup, int bitNo) {
    int vystup = vstup&(1<<bitNo);
    if(vystup == 0) {
        return 1;
    }
    else {
        return 0;
    }
}

void pohybMotoru(int smer, int idMotoru) {
    stavP2 = ~(idMotoru);
    if(smer == stavOtaceni_1) {
	 stavP2 = stavP2 & (~stavOtaceni_1);
    }
    else {
	stavP2 = stavP2|(stavOtaceni_1);
    }
    outb(stavP2, 0x301);
}

void init(void) {
    if(ioperm(0x300,2,1) != 0) {
        printf("Chyba \n");
        prava = 0;
        return;
    }

    //Zapis jednicek na P2
    stavP2 = 0xFF;
    outb(stavP2, 0x301);

    IROtaceniZakladny = vstupAktivni(inb(0x301), 0);
    IRRamenoChapadla = vstupAktivni(inb(0x301), 1);
    IRHlavniRameno = vstupAktivni(inb(0x301), 2);
    IRChapadlo = vstupAktivni(inb(0x301), 3);

    while(IROtaceniZakladny == 0) {
      pohybMotoru(stavOtaceni_1, motorOtaceniZakladny);
      taktovaniMotoru();
      IROtaceniZakladny = vstupAktivni(inb(0x301), 0);
    }
    while(IRRamenoChapadla == 0) {
      pohybMotoru(stavOtaceni_0, motorRamenoChapadlo);
      taktovaniMotoru();
      IRRamenoChapadla = vstupAktivni(inb(0x301), 1);
    }
    while(IRHlavniRameno == 0) {
      pohybMotoru(stavOtaceni_1, motorHlavniRameno);
      taktovaniMotoru();
      IRHlavniRameno = vstupAktivni(inb(0x301), 2);
    }
    while(IRChapadlo == 0) {
      pohybMotoru(stavOtaceni_1, motorChapadla);
      taktovaniMotoru();
      IRChapadlo = vstupAktivni(inb(0x301), 3);
    }
}

void vytvoritSoubor(char* nazevSouboru) {
        FILE *fp;

        printf("Zadejte nazev souboru:\n");
        scanf("%s", nazevSouboru);

        fp = fopen(nazevSouboru, "w");// vytvoreniSouboru
        fclose(fp);
}

void pridatDoSouboru(char *nazevSouboru, int obsahSouboru) {
        FILE *fp;

        fp = fopen(nazevSouboru, "a+");// vytvoreni odkazu na soubor
        fprintf(fp, "%d\n", obsahSouboru);
        fclose(fp);
}

void nacistSoubor() {
        FILE *f;
        char nazevSouboru[256];
        printf("Zadejte nazev souboru:\n");
        scanf("%s", nazevSouboru);
        f=fopen(nazevSouboru,"rt");

        char radek[256];
        int hodnota;

        int stavovaHodnota = 0;
        int cisloMotoru;
        int smer;
        while (fgets(radek, sizeof(radek), f)) {
                hodnota = atoi(radek);
                printf("Hodnota je %d\n", hodnota);
                switch (stavovaHodnota) {
                    case 0:
                        cisloMotoru = hodnota;
                        printf("Cislo motoru je: %d\n", cisloMotoru);
                        stavovaHodnota = stavovaHodnota + 1;
                    break;
                    case 1:
                	stavovaHodnota = stavovaHodnota + 1;
                        smer = hodnota;
                        printf("Smer je: %d, cisloMotoru: %d\n", smer, cisloMotoru);
                        pohybMotoru(smer, cisloMotoru);
                        taktovaniMotoru();
                        stavovaHodnota = 0;
                    break;
                }
        }
        fclose(f);
}

int main(void) {
    init();
    if(prava == 0) {
	     return;
    }

    while(1) {
        ovladaniVpravo = vstupAktivni(inb(0x300), 0);
        ovladaniVlevo = vstupAktivni(inb(0x300), 1);
        ovladaniDolu = vstupAktivni(inb(0x300), 2);
        ovladaniNahoru = vstupAktivni(inb(0x300), 3);
        attackerAktivni = vstupAktivni(inb(0x300), 4);

        IROtaceniZakladny = vstupAktivni(inb(0x301), 0);
        IRRamenoChapadla = vstupAktivni(inb(0x301), 1);
        IRHlavniRameno = vstupAktivni(inb(0x301), 2);
        IRChapadlo = vstupAktivni(inb(0x301), 3);

        if(attackerAktivni == 1 && ovladaniVlevo == 1) {
            pohybMotoru(stavOtaceni_1, motorChapadla);
            postupovaHodnota = 0;
            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorChapadla);
                pridatDoSouboru(nazevSouboru, stavOtaceni_1);
            }


            printf("Attacker a ovladani vlevo aktivni \n");
        }
        else if(attackerAktivni == 1 && ovladaniVpravo == 1) {
            pohybMotoru(stavOtaceni_0, motorChapadla);
            postupovaHodnota = 0;
            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorChapadla);
                pridatDoSouboru(nazevSouboru, stavOtaceni_0);
            }

            printf("Attacker a ovladani vpravo aktivni \n");
        }
        else if(attackerAktivni == 1 && ovladaniNahoru == 1) {
            pohybMotoru(stavOtaceni_0, motorRamenoChapadlo);
            postupovaHodnota = 0;
            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorRamenoChapadlo);
                pridatDoSouboru(nazevSouboru, stavOtaceni_0);
            }

            printf("Attacker a ovladani nahoru aktivni \n");
        }
        else if(attackerAktivni == 1 && ovladaniDolu == 1) {
            pohybMotoru(stavOtaceni_1, motorRamenoChapadlo);
            postupovaHodnota = 0;
            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorRamenoChapadlo);
                pridatDoSouboru(nazevSouboru, stavOtaceni_1);
            }

            printf("Attacker a ovladani dolu aktivni \n");
        }
        else if(ovladaniVlevo == 1) {
            pohybMotoru(stavOtaceni_1, motorOtaceniZakladny);
            postupovaHodnota = 0;
            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorOtaceniZakladny);
                pridatDoSouboru(nazevSouboru, stavOtaceni_0);
            }

            printf("Ovladani vlevo aktivni \n");
        }
        else if(ovladaniVpravo == 1) {
            pohybMotoru(stavOtaceni_0, motorOtaceniZakladny);
            postupovaHodnota = 0;
            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorOtaceniZakladny);
                pridatDoSouboru(nazevSouboru, stavOtaceni_1);
            }

            printf("Ovladani vpravo aktivni \n");
        }
        else  if(ovladaniDolu == 1) {
            pohybMotoru(stavOtaceni_0, motorHlavniRameno);
            postupovaHodnota = 0;
            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorHlavniRameno);
                pridatDoSouboru(nazevSouboru, stavOtaceni_0);
            }

            printf("Ovladani nahoru aktivni \n");
        }
        else if(ovladaniNahoru == 1) {
            pohybMotoru(stavOtaceni_1, motorHlavniRameno);
            postupovaHodnota = 0;

            if(spusteneNahravani == 1) {
                //Podle zvolene struktury - motor, smer
                pridatDoSouboru(nazevSouboru, motorHlavniRameno);
                pridatDoSouboru(nazevSouboru, stavOtaceni_1);
            }
            printf("Ovladani dolu aktivni \n");
        }
        else if(attackerAktivni == 1) {
            postupovaHodnota = postupovaHodnota + 1;

            if(postupovaHodnota == 100) {
                printf("Zvolte možnost z nabídky:\n");
                printf("1) Pro spusteni nahrávání kroků zvolte 1\n");
                printf("2) Pro ukonceni nahrávání kroků zvolte 2\n");
                printf("3) Pro nacteni ulozeneho souboru zvolte 3\n");
                printf("4) Pro ukonceni zvolte 4\n");

                char zvolenaHodnota[1];
                scanf("%s", zvolenaHodnota);
                int volba = atoi(zvolenaHodnota);

                switch (volba) {
                    case 1:
                        spusteneNahravani = 1;
                        vytvoritSoubor(nazevSouboru);
                    break;
                    case 2:
                        spusteneNahravani = 0;
                    break;
                    case 3:
                        nacistSoubor();
                    break;
                }
                postupovaHodnota = 0;
            }
        }
        else {
            stavP2 = 0xFF;
            outb(stavP2, 0x301);
            printf("Vypinani \n");
        }
        taktovaniMotoru();
    }
    return 1;
}