using System;
using System.IO;
using System.Collections.Generic;

namespace chatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            nevim nevim;
            nevim = new nevim(); // napsaní nevim co mam odpovědět objektově
            
            Dictionary<string, string> dic1 = new Dictionary<string, string>(); //použití listů
            
            zdravic zdravic;
            zdravic = new zdravic();

            zdravic.text = "Ahoj ";
            Console.WriteLine(zdravic.Pozdrav("Uživateli"));
            zdravic.text = "Vítá tě tu ";
            Console.WriteLine(zdravic.Pozdrav("Programátor"));
            nevim.napsat();
            
            using (StreamReader sr = new StreamReader(@"otazky.txt")) //rozdělení na odpovedi a otazky
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {                   
                    string[] spl = s.Split("*");
                    dic1.Add(spl[0], spl[1]); //pridani do listu
                    //var vals = s.Split("*")[0];
                    //var vals1 = s.Split("*")[1];
                    //Console.WriteLine(vals);
                    //Console.WriteLine(vals1);
                }
            }
            while (true) //cyklus
            {
                string text = Console.ReadLine();
                bool tf = false;
                foreach (var a in dic1)
                {

                    if (text == a.Key)
                    {
                        Console.WriteLine(a.Value);
                        tf = true;
                    }
                }
                if (!tf) //pokud neexistuje odpoved
                {
                    using (StreamWriter sw = new StreamWriter(@"otazky.txt", true)) //zapsani nové odpovedi
                    {
                        nevim.nevim1();                        
                        string odpoved2 = Console.ReadLine();
                        dic1.Add(text, odpoved2);
                        sw.WriteLine(text + "*" + odpoved2); //zapis do souboru
                        sw.Flush(); //vymazani bufferu
                    }
                }
                //Console.ReadLine();
            }
        }
    }
}
