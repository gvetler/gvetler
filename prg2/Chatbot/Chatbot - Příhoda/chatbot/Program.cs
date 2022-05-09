using System;
using System.IO;
using System.Collections.Generic;

namespace chatbot
{
    class Program
    {
        static void Main(string[] args)
        {
            //deklarace
            odpoved odpoved;
            odpoved = new odpoved(); // napsaní nevim co mam odpovědět objektově
            vypsani vypsani;
            vypsani = new vypsani();
            zdravic zdravic;
            zdravic = new zdravic();
            
            //použití zdraviče
            zdravic.text = "Zdravím ";
            Console.Write(zdravic.Pozdrav("Uživateli, "));
            zdravic.text = "tady ";
            Console.WriteLine(zdravic.Pozdrav("ChatBot"));
            odpoved.uvod();

            vypsani.vypis(); //hlavní funkce programu    
        }
    }
}
