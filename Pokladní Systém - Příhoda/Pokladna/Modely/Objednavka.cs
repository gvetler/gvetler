using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokladna.Modely
{
    class Objednavka
    {
        public int CisloObjednavky { get; set; }
        public int CelkovaCena { get; set; }

        public List<ZboziObjednavka> Zbozi { get; set; }

        public override string ToString()
        {
            return $"{CisloObjednavky}) {CelkovaCena} Kč";
        }
    }
}
