using System;

namespace Taylor
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * TAYLOROVA ŘADA
             * Vytvořit program, který vypočítá pomocí taylorovy řady 3 funkce - EXP, SIN, COS
             * Program bude počítat i s přesností na desetinná místa, která budou zvolena uživatelem či budou nastavena automaticky (2 des.)
             * ------------------------------------------------------------------------------------------------------------------------------------------------------------
             * Tento projekt obsahuje 3 třídy pro každou funkci, funkce jsou a musí být přetížené, každá funkce používá pomocnou funkci Factorial pro výpočet faktoriálu
             * Funkce jsou vytvořeny pomocí sigma notace viz soubor "Taylor Series"
             * ------------------------------------------------------------------------------------------------------------------------------------------------------------
             * NumberFormatInfo setPrecision = new CultureInfo("cs-CZ", false).NumberFormat;
             * setPrecision.NumberDecimalDigits = 2; default
             * nastavení přesnosti a formátu globálně, vlastní přesnost změna hodnoty *setPrecision = int a - class* ze vstupu *int presnost - main*
             * 
             */

            //
            tcos tcos = new tcos();
            tsin tsin = new tsin();
            texp texp = new texp();
            //
            Console.Write("****Taylorova řada****\n");
            Console.WriteLine("1. Exp\n2. Sin\n3. Cos");
            int pick = int.Parse(Console.ReadLine());
            if (pick > 3 || pick < 0) { Console.WriteLine("Chybně zadaný výběr"); Console.ReadLine(); Environment.Exit(0); }
            Console.WriteLine("Vlastní přesnost? Ano/Ne");
            var ans = Console.ReadLine();
            var answ = ans.ToLower();
            if (answ != "ano") { if (answ != "ne") { Console.WriteLine("Chybně zadaný výběr"); Console.ReadLine(); Environment.Exit(0); } }
            Console.WriteLine("Zadejte x:");
            double x = double.Parse(Console.ReadLine());

            if (answ == "ne")
            {
                switch (pick)
                {
                    case 1:
                        Console.WriteLine(texp.te(x));
                        break;
                    case 2:
                        Console.WriteLine(tsin.ts(x));
                        break;
                    case 3:
                        Console.WriteLine(tcos.tc(x));
                        break;
                    default:
                        Console.Write("err");
                        Environment.Exit(0);
                        break;
                }
            }
            if (answ == "ano")
            {
                Console.WriteLine("Zadejte přesnost:");
                int presnost = int.Parse(Console.ReadLine());

                switch (pick)
                {
                    case 1:
                        Console.WriteLine(texp.te(x, presnost));
                        break;
                    case 2:
                        Console.WriteLine(tsin.ts(x, presnost));
                        break;
                    case 3:
                        Console.WriteLine(tcos.tc(x, presnost));
                        break;
                    default:
                        Console.Write("err");
                        Environment.Exit(0);
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
