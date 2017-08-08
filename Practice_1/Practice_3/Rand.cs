using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_3
{
    public class Rand
    {
        private Random _rand;

        public Rand()
        {
            _rand = new Random();
        }
        public int Rand5()
        {
            return _rand.Next(0, 5);
        }

        public int Rand7()
        {
            int val = 0;
            for (int i = 0; i < 2; i++)
            {
                val *= 6;
                val += Rand5();
            }

            return val / 27;
        }
    }
}
