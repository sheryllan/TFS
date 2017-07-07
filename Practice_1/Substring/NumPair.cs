using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    public class NumPair
    {
        public int Solution(int[] array, int K)
        {
            var query = array.GroupBy(x => x)
                .OrderBy(x => x.Key)
                .Select(x => new {val = x.Key, count = x.Count()})
                .ToArray();

            int[] sortedArr = query.Select(x => x.val).ToArray();
            int count = 0;
            for (int i = 0; i < query.Length; i++)
            {
                int valToSearch;
                try
                {
                    checked
                    {
                        valToSearch = K - sortedArr[i];
                    }

                }
                catch (OverflowException e)
                {
                    continue;
                }
                
                
                if (valToSearch == sortedArr[i])
                {
                    count += (query[i].count - 1) * query[i].count / 2;
                }
                else
                {
                    int foundIdx = BinarySearch(sortedArr, valToSearch, i + 1);
                    if (foundIdx != -1)
                    {
                        count += query[i].count * query[foundIdx].count;
                    }
                }
            }
            return count;
        }

        public int BinarySearch(int[] array, int val, int start)
        {
            int end = array.Length - 1;
            
            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (array[mid] < val)
                    start = mid + 1;
                else if (array[mid] > val)
                    end = mid - 1;
                else
                    return mid;
               
            }

            return -1;
        }
    }
}
