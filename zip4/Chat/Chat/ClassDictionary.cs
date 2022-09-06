using System.Collections.Generic;

/*
DICTIONARY
https://docs.microsoft.com/cs-cz/dotnet/api/system.collections.generic.dictionary-2?view=net-5.0
*/

namespace Chat
{
    public class ClassDictionary
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public Dictionary<string, string> Dictionary { get => dictionary; set => dictionary = value; }
    }
}
