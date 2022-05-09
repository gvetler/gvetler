using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PristupovySystemRFID
{
    class PrevodySoustav
    {

        public static int prevodNaDesitkovouSoustavu(string cislo, int aktualniSoustava)
        {
            int vysledekVypoctu = 0;
            if (aktualniSoustava < 2 || aktualniSoustava > 16)
            {
                return -1;
            }

            List<string> poleMoznychHodnot = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

            string vstupniCislo = cislo;
            int desitkovaSoustava = 0;
            bool cisloJeZaporne = false;


            if (cislo.Substring(0, 1) == "+")
            {
                cisloJeZaporne = false;
                vstupniCislo = vstupniCislo.Substring(1);
            }
            else if (cislo.Substring(0, 1) == "-")
            {
                cisloJeZaporne = true;
                vstupniCislo = vstupniCislo.Substring(1);
            }

            foreach (char pismeno in vstupniCislo)
            {
                int index = 0;
                try
                {
                    index = poleMoznychHodnot.IndexOf(pismeno.ToString().ToUpper());
                }
                catch
                {
                    return -1;
                }

                if (index > (aktualniSoustava - 1) || index == -1)
                {
                    return -1;
                }

                int hodnotaZnaku;

                try
                {
                    hodnotaZnaku = int.Parse(pismeno.ToString());
                }
                catch
                {
                    hodnotaZnaku = index;
                }

                desitkovaSoustava += hodnotaZnaku;
                if (pismeno != vstupniCislo.Last()) desitkovaSoustava = desitkovaSoustava * aktualniSoustava;

            }

            if (cisloJeZaporne) desitkovaSoustava = (-1) * desitkovaSoustava;

            vysledekVypoctu = desitkovaSoustava;

            return vysledekVypoctu;
        }

        public static int vstupAktivni(int vstup, int cisloBitu)
        {
            if ((vstup & (1 << cisloBitu)) == 0) return 0;
            return 1;
        }
    }
}
