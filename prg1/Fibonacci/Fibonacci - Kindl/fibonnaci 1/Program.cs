using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

namespace fibonacci_1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Validace programu od 1 do 10");
            for(int b = 1; b<=10; b = b+1)
            {
                Console.Write("číslo :" + b + " = ");
                Console.Write(Fibonacci(b));
                Console.WriteLine();
            }

            Stopwatch sw = new Stopwatch();
            Console.WriteLine();
            Console.WriteLine("Fibonacciho posloupnost pro čísla: ");
            for (int cislo = 1; cislo <= 36; cislo = cislo + 1)
            {
                sw.Start();
                Console.Write("číslo :" + cislo + " = ");
                Console.Write(Fibonacci(cislo));
                sw.Stop();
                Console.WriteLine();
            }
            Console.WriteLine(" čas : " + sw.Elapsed);
            
            double[] pole = new double[37];
            pole[0] = 0;
            pole[1] = 1;
            Console.WriteLine("Zlatý řez pro první 36 čísel");
            for (int i = 2; i <= 36; i++)
            {
                pole[i] = pole[i - 1] + pole[i - 2];
                Console.WriteLine(pole[i] / pole[i - 1]);
            }
            double zr = (1 + Math.Sqrt(5)) / 2;
            Console.WriteLine("Zlatý řez vypočítaný pomocí vzorce : " + zr);
            Console.WriteLine("K zlatému řezu jsem se dostal podílem dvou po sobe jdoucích číslech po prvních 36 číslách.");
            Console.WriteLine("Takže tvrzení, zda konverguje podíl dvou po sobě jdnoucích Fibonacciho čísel k číslu zlatý řez je pravdivé.");
            Console.WriteLine();
            Console.WriteLine("Fibonacciho číslo pro vstup 10 001: ");
            BigInteger[] pole1 = new BigInteger[10002];
            pole1[0] = 0;
            pole1[1] = 1;
            for (int i = 2; i <= 10001; i++)
            {
                pole1[i] = pole1[i - 1] + pole1[i - 2];
            }
            Console.WriteLine(pole1[10001]);

            Console.ReadLine();
        }

        private static double Fibonacci(int cislo)
        {
            if (cislo == 0)
            {
                return 0;
            }
            else if (cislo == 1)
            {
                return 1;
            }
            else
            {
                return (Fibonacci(cislo - 1) + Fibonacci(cislo - 2));

            }
        }
    }
}
