int setBit(int hodnota, int bitNo) {
  int maska = 1<<bitNo;
  int vyslednaHodnota = maska|hodnota;
  return vyslednaHodnota;
}

int clearBit(int hodnota, int bitNo) {
  int maska = ~(1 << bitNo);
  int vyslednaHodnota = maska & hodnota;
  return vyslednaHodnota;
}

int toggleBit(int hodnota, int bitNo) {
  int maska = 1<<bitNo;
  int vyslednaHodnota = maska ^ hodnota;
  return vyslednaHodnota;
}

int bitStatus(int hodnota, int bitNo) { //pokud je nastaven, vrati true(1); pokud ne, vrati false(0)
  int maska = 1<<bitNo;
  int vyslednaHodnota = maska & hodnota;
  if(vyslednaHodnota == 0) {
    return 0;
  }
  else {
    return 1;
  }
}
