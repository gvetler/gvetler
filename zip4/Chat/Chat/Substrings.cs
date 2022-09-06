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
    public class Substrings : ClassDictionary
    {

        public void Sub()
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("chatbot.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Split a delimited string into substrings
                        string[] Split = line.Split("|");
                        // Add substrings into dictionary ( string | string )
                        Dictionary.Add(Split[0], Split[1]);
                    }

                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

    }
}
