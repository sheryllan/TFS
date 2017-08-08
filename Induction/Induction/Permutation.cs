using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Induction
{
    public class Permutation
    {
        public void GenPermutation(int[] A)
        {
            foreach (var p in GenPerm_Recusive(A, 0))
            {
                Console.WriteLine();
                foreach (var num in p)
                {
                    Console.Write(num + " ");
                }
            }
            
        }

        private IEnumerable<int[]> GenPerm_Recusive(int[] A, int toSwap)
        {
            if (toSwap == A.Length - 1)
                yield return A;

            for (int i = toSwap; i < A.Length; i++)
            {
                Swap(ref A[i], ref A[toSwap]);
                GenPerm_Recusive(A, toSwap + 1);
                Swap(ref A[i], ref A[toSwap]);

            }
            
        }

        private void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
