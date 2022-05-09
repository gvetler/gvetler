using System;
using System.Numerics;

namespace fibonacci_own
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítej ve fibonnaciho aplikaci!");
            



            int pocetcisel = 46;

            int[] pole = new int[pocetcisel];
            
            double zlatyrez=0;
            for (int i=2;i<pole.Length;i++)
            {
                
                pole[0] = 0;
                pole[1] = 1;

                pole[i] = pole[i - 1] + pole[i - 2];

                double cislo1 = pole[i - 1];
                double cislo2 = pole[i - 2];



                zlatyrez = cislo1 / cislo2;

                Console.WriteLine(Convert.ToString(pole[i]));
                

               // Console.WriteLine(Convert.ToString(zlatyrez));

            }


            Console.WriteLine("///////////");
            Console.WriteLine(Convert.ToString(zlatyrez));

            


        }
    }
}
