using System;
using System.Diagnostics;
using System.Numerics;

namespace Cislo
{
    class Program
    { 
        public static double Fibonacci(int a)
        {
            if (a < 2)
            {
                return a;
            }
            else
            {
                return (Fibonacci(a - 1) + Fibonacci(a - 2));
            }
        }
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            for (int a = 20; a <= 40; a = a + 2)
            {
                    Console.Write("Pro číslo : " + a + " =  ");
                    st.Start();
                    Console.Write(Fibonacci(a));
                    st.Stop();
                    Console.WriteLine("   Výsledky časů seřazení : " + st.Elapsed);
            }
            double[] pole = new double[51];
            pole[0] = 0;
            pole[1] = 1;
            for (int i = 2; i < 50; i++)
            {
                pole[i] = pole[i - 1] + pole[i - 2];  
            }
            double zlrez = (1 + Math.Sqrt(5)) / 2;
            Console.WriteLine("------------------------");
            Console.WriteLine("Dělění prvních 20 Fibonacciho čísel : ");
            for (int i = 2; i < 50; i++ )
            {
                
                Console.WriteLine(pole[i] / pole[i - 1]);
            }
            Console.WriteLine("------------------------");
            Console.WriteLine("Zlatý řez : " + zlrez);
            Console.WriteLine("Dělění dvou po sobě jdoucích Fibonacciho čísel se přibližuje zlatému řezu, čím větší dvě čísla po sobě jdou");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Zkouška pro 10001 čísel : " );
            Console.WriteLine("Výsledek : ");
            
            BigInteger[] pole1 = new BigInteger[10002];
            pole1[0] = 0;
            pole1[1] = 1;
            for (int i = 2; i < pole1.Length; i++)
            {
                pole1[i] = pole1[i - 1] + pole1[i - 2];
            }
            Console.WriteLine(pole1[10001]);
            Console.ReadLine();
            
            //Vypočítal jsem, že vždy, čím více zvýším sečtených dvou čísel, tím více se to přibližuje zlatému řezu. 
            //Vypočet zlatého řezu zní takto : (1 + √5) / 2 = 1,618033988.... . 
            //Pro výpočet Fibonacciho čísla ( 10001 ) jsem musel použít System.Numerics, přičemž k poli jsem musel místo double (což vyhazovalo ? ) použít BigInteger.
            //Zadal jsem vstupní hodnoty od 20, postupně zvyšuji po 2 do 40.
            
        }
    }
}
