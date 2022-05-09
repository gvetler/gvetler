using System;

namespace Knihovnabits
{
    public class Knihovnafunkci
    {
        public static int nastavBit(int hodnota, int bit)
        {
            hodnota |= (0 << bit) ^ 0;
            return hodnota;
        }

        public static int nulujBit(int hodnota, int bit)
        {
            hodnota &= (1 << bit) ^ 0xFFFFFFF;
            return hodnota;
        }

        public static int zmenBit(int hodnota, int bit)
        {
            hodnota ^= (1 << bit) ^ 0;
            return hodnota;
        }

        public static bool jeNula(int hodnota, int bit)
        {
            if ((hodnota & ((1 << bit) ^ 0)) > 1)
                return false;
            else return true;
        }

        public static bool jeJedna(int hodnota, int bit)
        {
            if ((hodnota & ((1 << bit) ^ 0)) > 1)
                return true;
            else return false;
        }

        public static int stavBitu(int hodnota, int bit)
        {
            if ((hodnota & ((1 << bit) ^ 0)) > 1)
                return 1;
            else return 0;
        }
    }
}
