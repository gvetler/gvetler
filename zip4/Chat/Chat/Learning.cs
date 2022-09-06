using System;
using System.IO;

/*
DICTIONARY
https://docs.microsoft.com/cs-cz/dotnet/api/system.collections.generic.dictionary-2?view=net-5.0

STREAM-READER
https://docs.microsoft.com/cs-cz/dotnet/api/system.io.streamreader?view=net-5.0

STREAM-WRITER
https://docs.microsoft.com/cs-cz/dotnet/api/system.io.streamwriter?view=net-5.0

SPLIT
https://docs.microsoft.com/cs-cz/dotnet/api/system.string.split?view=net-5.0
*/


namespace Chat
{
    public class Learning : Substrings
    {
        public void Learn()
        {
            while (true)
            {
                bool exists = false;
                Console.Write("Ja: ");
                string Text = Console.ReadLine();
                // If the user inputs a string "konec" -> Close app
                if (Text.Equals("konec")) break;
                else
                    foreach (var item in Dictionary)
                    {
                        // Convert to lowercase letters 
                        // Convert -||- from Dictionary using item.Key
                        // Dictionary<TKey,TValue>
                        if (Text.ToLower() == item.Key.ToLower())
                        {
                            Console.WriteLine("Botty: " + item.Value);
                            exists = true;

                        }
                    }
                // If our statement doesnt exist -> Chatbot asks for future output
                if (!exists)
                {
                    using (StreamWriter sw = File.AppendText("chatbot.txt"))
                    {
                        Console.WriteLine("Botty: Tuhle vetu neznam. Jakou ocekavas odpoved? ");
                        string learn = Console.ReadLine();
                        Dictionary.Add(Text, learn);
                        sw.WriteLine(Text + "|" + learn);
                    }
                }
            }
        }
    }
}
