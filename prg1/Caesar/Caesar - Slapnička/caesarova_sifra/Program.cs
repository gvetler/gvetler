using System;

namespace caesarova_sifra
{
    class Program
    {
        static char[] znaky = { 'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',' '};//27znaku-nevim jestli obsahuje cisla(rimane nemeli latinske cislovani takze asi ne)

        static string operace(string text,int posun)
        {
            char[] text_na_znaky = text.ToCharArray();//prevod string na pole charu
            int delka = text_na_znaky.Length;//zjisteni delky pole
            for (int i = 0; i <delka; i++)
            {
                for (int x = 0; x <= 26; x++)
                {   
                    if (text_na_znaky[i] == znaky[x])
                    {
                        if ((x + 4) >= 27)//podminka proti preteceni pole
                            text_na_znaky[i] = znaky[x + posun-27];
                        if ((x + 4) < 27)
                            text_na_znaky[i] = znaky[x + posun];
                        break;
                    }
                }
            }
            string charsStr = new string(text_na_znaky);//prevod pole char na string
            return charsStr;
        }
        static void Main(string[] args)
        {
            string zadanytext;
            Console.WriteLine("-------zadej vetu-------");
            zadanytext = Console.ReadLine();
            zadanytext = zadanytext.ToLower();
            Console.WriteLine("---zadej delku posunu---");
            int sifrakey =  Convert.ToInt32(Console.ReadLine());//zadani posunu a prevod do int
            Console.WriteLine("----zasifrovana veta----\n" + operace(zadanytext,sifrakey));
        }
    }
}
