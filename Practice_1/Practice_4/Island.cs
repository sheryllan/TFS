using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4
{
    public class Island
    {
        struct land
        {
            public int edge_left;
            public int edge_right;
            public int size;
        }
        public int FindNumOfIsland(int[][] A, int k)
        {
            int count = 0;
            List<land> prevKs = new List<land>();
            List<land> currKs;
            for (int i = 0; i < A.Rank; i++)
            {
                currKs = ConnectionOfARow(A[i], k);
                foreach (var prevK in prevKs)
                {
                    
                }
                
                

                prevKs = ConnectionOfARow(A[i], k);

            }
            return count;
        }

        private List<land> ConnectionOfARow(int[] A, int k)
        {
            var results = new List<land>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == k)
                {
                    var land = new land {edge_left = i, size = 1};
                    while (A[i] == k)
                    {
                        land.size++;
                        i++;
                    }
                    land.edge_right = i;
                    results.Add(land);
                }

            }
            return results;
        }
    }
}
