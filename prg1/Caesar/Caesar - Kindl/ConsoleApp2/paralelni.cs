using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp2
{
    class paralelni
    {
        public delegate void ThreadStart();
        public void sifruj()
        {
            Console.WriteLine("Zadej vstup");
            char[] znaky = Console.ReadLine().ToCharArray();
            string vysledek = "";
            Console.WriteLine("Zadej o kolik chceš posunout");
            int posun = int.Parse(Console.ReadLine());
            foreach (char znak in znaky)
            {
                if (znak >= 'A' && znak <= 'Z')
                {
                    if ((znak + posun) > 'Z')
                    {
                        vysledek += Convert.ToChar(((int)znak + posun) - (26)).ToString();
                    }
                    else
                    {
                        vysledek += Convert.ToChar((int)znak + posun).ToString();
                    }
                }
                if (znak >= 'a' && (int)znak <= 'z')
                {
                    if ((znak + posun) > 'z')
                    {
                        vysledek += Convert.ToChar(((int)znak + posun) - (26)).ToString();
                    }
                    else
                    {
                        vysledek += Convert.ToChar((int)znak + posun).ToString();
                    }
                }

            }
            Console.WriteLine(vysledek);
        }
        


        public void desifruj()
        {
            Console.WriteLine("Zadej vstup na dešifrování");
            char[] znaky = Console.ReadLine().ToCharArray();
            Console.WriteLine("Zadej posun");
            int posun = int.Parse(Console.ReadLine());
            string vysledek = "";
            foreach (char znak in znaky)
            {
                if (znak >= 'A' && znak <= 'Z')
                {
                    if ((znak + posun) > 'Z')
                    {
                        vysledek += Convert.ToChar(((int)znak - posun) - (26)).ToString();
                    }
                    else
                    {
                        vysledek += Convert.ToChar((int)znak - posun).ToString();
                    }
                }
                if (znak >= 'a' && (int)znak <= 'z')
                {
                    if ((znak + posun) > 'z')
                    {
                        vysledek += Convert.ToChar(((int)znak - posun) - (26)).ToString();
                    }
                    else
                    {
                        vysledek += Convert.ToChar((int)znak - posun).ToString();
                    }
                }

            }
            Console.WriteLine(vysledek);
        }
        public void prepinej()
        {
         
            Thread vlakna = new Thread(sifruj);
            vlakna.Start();
            vlakna.Join();
            Thread vlakna2 = new Thread(desifruj);
            vlakna2.Start();  
            vlakna2.Join();
        }
    }
}
