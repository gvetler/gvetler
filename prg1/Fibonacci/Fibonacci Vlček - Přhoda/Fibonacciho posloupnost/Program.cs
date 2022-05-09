using System;
using System.Diagnostics;
using System.Numerics;

namespace Fibonacciho_posloupnost
{
    class Program
    {
        static void Main()
        {

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Fibonacciho posloupnost pro 40 čísel: ");
            
            for (int i = 0; i < 40; i++)
            {
                sw.Start();
                Console.WriteLine(Fibonacci(i));
                sw.Stop();
            }
            Console.WriteLine();
            Console.WriteLine("Čas : " + sw.Elapsed);

            Console.WriteLine();
            Console.WriteLine("Validace:");
            for (int a = 1; a <= 20; a = a + 1)
            {
                Console.Write("Pro číslo: " + a + " = ");
                Console.Write(Fibonacci(a));
                Console.WriteLine();
            }

            float[] arr = new float[41];
            arr[0] = 0;
            arr[1] = 1;

            Console.WriteLine();
            Console.WriteLine("Zlatý řez:");
            for (int i = 2; i <= 40; i++)
            {
                arr[i] = arr[i - 1] + arr[i - 2];
                Console.WriteLine(arr[i] / arr[i - 1]);
            }
            double gr = (1 + Math.Sqrt(5)) / 2;
            Console.WriteLine();
            Console.WriteLine("Zlatý řez jsem vypočítal podílem dvou po sobě jdoucích číslech.");
            Console.WriteLine("Tudíž je pravda, že podíl dvou po sobě jdoucích členů konverguje k hodnotě zlatého řezu α = (1+√5) / 2 ≈ 1,618.");

            Console.WriteLine();
            Console.WriteLine("Fibonacciho číslo pro vstup 10 001: ");

            BigInteger[] arr2 = new BigInteger[10002];

            arr2[0] = 0;
            arr2[1] = 1;

            for (int i = 2; i <= 10001; i++)
            {
                arr2[i] = arr2[i - 1] + arr2[i - 2];
            }
            Console.WriteLine(arr2[10001]);

            Console.ReadLine();
        }

        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;
            
            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return a;
        }
        
    }
}
  