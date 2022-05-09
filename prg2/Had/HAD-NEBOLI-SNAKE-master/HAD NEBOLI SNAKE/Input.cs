using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HAD_NEBOLI_SNAKE
{
        internal class Input
        {
            //list použitelných kláves
            private static Hashtable keyTable = new Hashtable();

            //Provede kontrolu jestli je správná klavesa zmáčknutá
            public static bool KeyPressed(Keys key)
            {
                if (keyTable[key] == null)
                {
                    return false;
                }

                return (bool)keyTable[key];
            }

            //Detekce zmáčnkutí klávesy
            public static void ChangeState(Keys key, bool state)
            {
                keyTable[key] = state;
            }
        }
    
}
 