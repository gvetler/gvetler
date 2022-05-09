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
            int o = 1000;
            long součet = 0;

            
            for (int k = 0; k < 10; k++)
            {
                Console.Write("Časy pro " + o + " prvků : ");
                int pullitr = 0;
                for (int u = 0; u < 10; u++)
                {
                    Random gg = new Random();
                    int[] pole = new int[o];
                  

                    for (int i = 0; i < pole.Length -1; i++)
                    {
                        pole[i] = gg.Next();
                    }

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    for (int i = 0; i < pole.Length - 1; i++)
                    {
                        for (int j = 0; j < pole.Length - i - 1; j++)
                        {
                            if (pole[j + 1] < pole[j])
                            {
                                int a = pole[j + 1];
                                pole[j + 1] = pole[j];
                                pole[j] = a;


                            }
                            
                        }
                        
                    }
                    
                    stopWatch.Stop(); 
                    Console.Write(  + stopWatch.ElapsedMilliseconds + "  ");
                    pullitr += Convert.ToInt32(stopWatch.ElapsedMilliseconds);
                    




                for (int j = 0; j < pole.Length; j++)
                {
                        součet += pole[j];
                    }
                    
                   
                    
                }
                double průměr = pullitr / 10;
                Console.WriteLine(" |   Průměr je : " + průměr);
                o = o + 250;
                Console.WriteLine();
            }
            Console.Read();           
        }

          //Zjistil jsem, že pokuď pro zadanou hodnotu nechám vypočítat 30 časů, v mnoha případech se liší. Když vypočítám. Když zprůměruju těchto 30 časů pro každou hodnotu, tak by mělo pravděpodobně asymptoticky čas narůstat, což se
          //něděje, takže jsem si ověřil, že to tak , jak potřebujeme nefunguje.
    }
}















