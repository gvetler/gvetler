#include <stdio.h>
#include "BitoveManipulace.h"

int main() {
  int hodnota = setBit(5, 6);
  printf("Hodnota po nastavení 6. bitu na desítkové hodnotě 5 je: %d \n", hodnota);

  hodnota = clearBit(hodnota, 6);
  printf("Hodnota po vypnutí 6. bitu na desítkové hodnotě 69 je: %d \n", hodnota);

  hodnota = toggleBit(100, 5);
  printf("Hodnota po přepnutí 5. bitu na desítkové hodnotě 100 je: %d \n", hodnota);

  hodnota = toggleBit(hodnota, 5);
  printf("Hodnota po dalším přepnutí 5. bitu je: %d \n", hodnota);

  int patyBit = bitStatus(hodnota, 5);
  printf("Hodnota %d má na 5. bitu logickou %d \n", hodnota, patyBit);

  int druhyBit = bitStatus(hodnota, 1);
  printf("Hodnota %d má na 1. bitu logickou %d \n", hodnota, druhyBit);

  return 0;
}
