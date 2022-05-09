#include <stdio.h>

// funkce na převod na binární čísla
void bin(unsigned n)
{
    unsigned i;
    for (i = 1 << 7; i > 0; i = i / 2)
        (n & i) ? printf("1") : printf("0");
}

int main(void) {
    //základní hodnota kterou budu měnit operacemi
    int zakladnibit = 0b11000110;

    //maska
    int nastavujicibit1 = 0b00101000;
    //operace OR
    int vysledek1 = zakladnibit | nastavujicibit1;
    printf("Výsledek číslo 1: %d\n", vysledek1);

    //maska
    int nastavujicibit2 = 0b00000010;
    //operace AND
    int vysledek2 = zakladnibit & nastavujicibit2;
    printf("Výsledek číslo 2: %d\n", vysledek2);

    //funkce na zjištění hodnoty 7. bitu
    if((zakladnibit & 0b10000000) == 0b10000000)
    {
        //když je 7. bit  v log. 1 = operace XOR 
        int nastavujicibit3 = 0b00101000;
        int vysledek3 = zakladnibit ^ nastavujicibit3;
        printf("Výsledek číslo 3: %d\n", vysledek3);

            //binární hodnoty
            printf("Výsledky v binárních hodnotách:");
            printf("\n");
            printf("Výsledek číslo 1: "); bin(vysledek1);
            printf("\n");
            printf("Výsledek číslo 2: "); bin(vysledek2);
            printf("\n");
            printf("Výsledek číslo 3: "); bin(vysledek3);
    }
    else printf("Výsledek číslo 3: 7. bit není v logické 1: \n");
    return 0;
}