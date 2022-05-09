using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace chatbot
{
    class vypsani
    {
        public Dictionary<string, string> dic1 = new Dictionary<string, string>(); //použití dictionary

        public void vypis()
        {
            odpoved odpoved;
            odpoved = new odpoved();

            using (StreamReader sr = new StreamReader(@"otazky.txt")) // čtení souboru
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] spl = s.Split("*"); //rozdělení textu na odpovedi a otazky
                    dic1.Add(spl[0], spl[1]); //pridani do listu
                }
            }
            while (true)
            {
                Console.Write("Uživatel: ");
                string text = Console.ReadLine();

                bool tf = false;
                foreach (var a in dic1) 
                {
                    if (text.ToLower() == a.Key.ToLower()) //když najde otázku => napíše chatbot odpoved
                    {
                        Console.Write("ChatBot: ");
                        Console.WriteLine(a.Value);
                        tf = true;
                    }
                }
                if (!tf) //pokud neexistuje odpoved
                {
                    using (StreamWriter sw = new StreamWriter(@"otazky.txt", true)) //zapsani nové odpovedi do souboru
                    {
                        Console.Write("ChatBot: ");
                        odpoved.nevim();
                        Console.Write("Uživatel: ");
                        string odpoved2 = Console.ReadLine();
                        dic1.Add(text, odpoved2);
                        sw.WriteLine(text + "*" + odpoved2); //zapis do souboru
                        sw.Flush(); //vymazani bufferu
                    }
                }
                
            }
        }
    }
}
