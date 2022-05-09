using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eratosthenovo_síto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Zadej horní mez intervalu: ");
            int max = int.Parse(Console.ReadLine());

            int[] pole = new int[max];
            int podminka = 0;

            for (int i = 0; i < pole.Length - 1; i++)
            {
                pole[i] = i + 2;
            }

            for (int i = 0; i < Math.Sqrt(pole.Max()); i++)
            {
                for (int j = 2; j < pole.Max(); j++)
                {
                    if (pole.Contains(pole[i] * j) && pole[i] != 0)
                    {
                        podminka = (pole[i] * j) - 2;
                        pole[podminka] = 0;
                    }
                }
            }
            Console.WriteLine("Výpis prvočísel: ");
            for (int i = 0; i < pole.Length - 1; i++)
            {
                if (pole[i] != 0)
                {
                    Console.WriteLine("- " + pole[i]);
                }
            }

            Console.ReadKey();
        }
    }
}
