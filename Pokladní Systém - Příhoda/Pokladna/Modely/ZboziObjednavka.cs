using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokladna.Modely
{
    class ZboziObjednavka
    {
        public Zbozi Zbozi { get; set; }
        public int Objednavka { get; set; }
        public int Pocet { get; set; }

        public override string ToString()
        {
            return $"{Zbozi} {Pocet}";
        }
    }
}
