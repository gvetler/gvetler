using System;
using System.Collections.Generic;
using System.Text;

namespace chatbot
{
    class zdravic
    {
        public string text;
       
        public string Pozdrav(string jmeno)
        {
            return String.Format("{0} {1}", text, jmeno);
        }
    }
}
