using System;
using System.Diagnostics;

namespace BubblesortOWN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Aplikace bubblesort");


            int pocetcisel = 2000;
            long ulozitcislo = 0;
            
            


            for (int i =0; i<10; i++)
            {
                Console.Write("casy pro " + pocetcisel + "čísel.");

                int b = 0;

                for(int k=0; k<15; k++)
                {
                    Random gg = new Random();
                    
                    int[] pole = new int[pocetcisel];

                    for (int j = 0; j<pole.Length -1; j++)
                    {
                        pole[j] = gg.Next();





                    }

                    Stopwatch stopky = new Stopwatch();
                    stopky.Start();

                    for (int o=0; o<pole.Length - 1; o++)
                    {
                        for(int l=0;l<pole.Length-1 -o; l++)
                        {
                            if (pole[l + 1] < pole[l])
                            {
                                int a = pole[l + 1];
                                pole[l] = pole[l + 1];
                                pole[l] = a;
                            }
                        }


                    }
                    stopky.Stop();
                    Console.Write(+ stopky.ElapsedMilliseconds+" ");
                    b += Convert.ToInt32(stopky.ElapsedMilliseconds);

                    

                }


                double prumercasu = b/15;
                Console.WriteLine("prumer je:" + prumercasu);
                pocetcisel += 500;

            }


            Console.Read();


        }

    }
}
