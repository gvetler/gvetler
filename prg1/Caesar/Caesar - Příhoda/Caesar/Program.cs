using System;

namespace Caesar
{
    class Program
    {
        static char Sifra(char ch, int key)
        {
            // ošetření
            if (!char.IsLetter(ch))
            {
                return ch;
            }

            // vzorec = (ch + key) % m
            // ch - znak otevřeného textu, key - posun, m - délka abecedy
            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }

        static string Zasifrovani(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += Sifra(ch, key);

            return output;
        }

        static string Desifrovani(string input, int key)
        {
            return Zasifrovani(input, 26 - key);
        }


        static void Main(string[] args)
        {

            Console.WriteLine("Data která chcete zašifrovat a nebo dešifrovat: ");
            string UserString = Console.ReadLine();
            Console.WriteLine("\n");

            Console.Write("Počet míst: ");
            int key = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");


            Console.WriteLine("Zašifrovaná data");
            string cipherText = Zasifrovani(UserString, key);
            Console.WriteLine(cipherText);
            Console.Write("\n");

            Console.WriteLine("Rozšifrovaná data:");

            string t = Desifrovani(cipherText, key);
            Console.WriteLine(t);
            Console.Write("\n");

            Console.ReadKey();

        }
    }
}

