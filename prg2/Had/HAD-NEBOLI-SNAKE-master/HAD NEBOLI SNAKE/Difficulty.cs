using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAD_NEBOLI_SNAKE
{
    class Difficulty
    {
        // název v aplikaci
        public string Name;
        // základní počet bodů za jedno ovoce
        public int ScoreInc;
        // počet přeskočených updatů okna
        public int SkipCount;

        public Difficulty(string Name, int ScoreInc, int SkipCount)
        {
            this.Name = Name;
            this.ScoreInc = ScoreInc;
            this.SkipCount = SkipCount;
        }
    }
}
