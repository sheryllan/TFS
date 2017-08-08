using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Induction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = {1, 2, 3, 4, 5};
            Permutation permutation = new Permutation();
            permutation.GenPermutation(A);

            Console.ReadKey();
        }
    }
}
