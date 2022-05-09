using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAD_NEBOLI_SNAKE
{
    /// <summary>
    /// Třída objektu na mapě, obsahuje jeho souřadnice a rozměry
    /// </summary>
    public class MapObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width;
        public int Height;

        public MapObject()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
        }

        public MapObject(int X, int Y, int Width = 1, int Height = 1)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }

        /// <summary>
        /// Zkontroluje jestli je část objektu na zadaných souřadnicích
        /// </summary>
        /// <returns>TRUE když se tam objekt nachází, FALSE když ne</returns>
        public bool IsColliding(int CheckX, int CheckY)
        {
            for(int i = X; i < X + Width; i++)
            {
                // if (CheckX != X + Width) continue;
                for (int j = Y; j < Y + Height; j++)
                {
                    if (CheckX == i && CheckY == j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
