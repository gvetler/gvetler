using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokladna.Modely
{
    class Zbozi
    {
        public long Kod { get; set; }
        public string Nazev { get; set; }
        public string Kategorie { get; set; }
        public int Cena { get; set; }
        public int MnozstviNaSklade { get; set; }
        public override string ToString()
        {
            return this.Nazev;
        }
    }
}
