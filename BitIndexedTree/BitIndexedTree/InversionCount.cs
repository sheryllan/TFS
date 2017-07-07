using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitIndexedTree
{
    public class InversionCount
    {
        // Initialize the BIT and decrease frequency at each iteration
        public int Solution(int[] A)
        {
            // Have to ensure the sorted array stable - stable sorting - so that this solution works

            var indexArr = A.Select((x, i) => new {val = x, index = i}).GroupBy(x => x.val, x => x.index)
                .OrderBy(x => x.Key).Select(x => x.OrderBy(y => y)).SelectMany(x => x);
            
            var indexDict = indexArr.Select((x, i) => new {val = x, index = i}) // val is the index before sorting, hence unique
                .ToDictionary(x => x.val, x => x.index);

            var frequencies = new int[A.Length];
            frequencies = frequencies.Select(f => 1).ToArray();
            var tree = CreateBitIndexTree(frequencies);

            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int j = indexDict[i];
                count += ReadCulmulativeFrequency(tree, j + 1);
                UpdateBitIndexTree(ref tree, j + 1, -frequencies[j]);
            }

            return count;
        }

        // Building the BIT up adding frequency at each iteration
        public int Solution2(int[] A)
        {
            var indexArrOld = A.Select((x, i) => new { val = x, index = i }).GroupBy(x => x.val, x => x.index)
               .OrderBy(x => x.Key).Select(x => x.OrderBy(y => y)).SelectMany(x => x);

            var indexArrNew = indexArrOld.Select((x, i) => new {oldIdx = x, newIdx = i})
                .OrderBy(x => x.oldIdx).Select(x => x.newIdx).ToArray();

            int[] tree = A.Select(x => 0).ToArray();
            int count = 0;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                int j = indexArrNew[i];
                count += ReadCulmulativeFrequency(tree, j + 1);
                UpdateBitIndexTree(ref tree, j + 1, 1);
            }
            return count;
        }

        public int[] CreateBitIndexTree(int[] frequencies)
        {
            int[] culmulative = new int[frequencies.Length];
            int[] tree = new int[frequencies.Length];
            culmulative[0] = 0;
            tree[0] = culmulative[0];
            for (int i = 1, j = 0; i < frequencies.Length; i++, j++)
            {
                culmulative[i] = culmulative[j] + frequencies[j];

                int lastDigit = i + 1 - ((i + 1) & -(i + 1));
                tree[i] = lastDigit > 0 ? culmulative[i] - culmulative[lastDigit - 1] : culmulative[i]; // frequency from lastDigit to i
            }
            return tree;
        }

        public int ReadCulmulativeFrequency(int[] tree, int index) // index is 1-based
        {
            int sum = 0;
            while (index > 0)
            {
                sum += tree[index - 1];
                index -= (index & -index) ;
            }
            return sum;
        }

        public void UpdateBitIndexTree(ref int[] tree, int index, int val) // index is 1-based
        {
            while (index <= tree.Length)
            {
                tree[index - 1] += val;
                index += (index & -index);
            }
        }
           
    }
}
