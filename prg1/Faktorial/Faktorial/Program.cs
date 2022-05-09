using System;

namespace Faktorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int faktorial = 1;
            Console.WriteLine("Zadej číslo: ");
            int x = int.Parse(Console.ReadLine());
            if (x >= 25)
            {
                Console.WriteLine("Číslo je příliš vysoké!");
                Environment.Exit(0);
            }

            if (x <= 0)
            {
                Console.WriteLine("Číslo se nesmí rovnat, nebo být menší než nula!");
                Environment.Exit(0);
            }
            Console.ReadLine();

            for (int i=1; i<=x; i++)
            {
                faktorial *= i;
            }
            Console.WriteLine("BEZ REKURZE: ");
            Console.WriteLine(faktorial);
            Console.WriteLine("REKUZRE: ");
            long faktorialrekurziv = RekurzivFaktorial(x);
            Console.WriteLine(faktorialrekurziv);
            Console.ReadLine();
        }
        public static long RekurzivFaktorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }

            return x * RekurzivFaktorial(x - 1);

        }
    }
}

