using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch quick = new Stopwatch();
           
            long[] poleprum = new long[11];

            
                for (int L = 10000; L <=  100000; L= L + 10000)

        {
                TimeSpan prumer = new TimeSpan();
                for (int j = 1; j < 11; j++)
                {
                    quick.Start();

            Random lol = new Random();
            int[] cisla = new int[L];
            for (int i = 0; i < cisla.Length; i++)
            {
                cisla[i] = lol.Next();
            }

            int[] array = cisla;
            QUICK(array, 0, array.Length);
                    
                   quick.Stop();
                    Console.Write("Pro číslo : " + L + " =  ");
                    Console.WriteLine("   Výsledky časů seřazení : " + quick.Elapsed);
                    prumer = prumer + quick.Elapsed;
                }
                prumer = prumer / 2;
                poleprum[L / 10000] = prumer.Ticks;
                Console.WriteLine("--------------------");
        }
            foreach (long a in poleprum)
            {
                if (a != 0)
                Console.WriteLine("Průměr pro hodnoty určené hodnoty po sobě jdoucích : " + a + "   ");
            }
            static void PrintArray(int[] array)
            {
                
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.WriteLine();
        }

        static void QUICK(int[] array, int a, int b)
        {
            if (b > a)
            {

                int border = a;
                int tmp;

                for (int i = a + 1; i < b; i++)
                {
                    if (array[a] > array[i])
                    {

                        border++;

                        tmp = array[i];
                        array[i] = array[border];
                        array[border] = tmp;
                    }
                }

                tmp = array[a];
                array[a] = array[border];
                array[border] = tmp;

                QUICK(array, a, border);
                QUICK(array, border + 1, b);
                    }
                }
            //Výsledek průměrů mám v tickách, Bohužel časovou složitost nevím, jak mám ověřit. Zvyšuju hodnoty po 10000.
        }
    }
}






