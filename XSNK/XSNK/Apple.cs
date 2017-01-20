using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XSNK
{
    class Apple
    {
        private int[] position;

        public Apple()
        {
            position = new int[2];
        }

        public int[] Spawn(int heigth, int width)
        {

            Random random = new Random();
            position[0] = random.Next(heigth - 3) + 1;
            position[1] = random.Next(width - 3) + 1;
            return position;
        }
    }
}
