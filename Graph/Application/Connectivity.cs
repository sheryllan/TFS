using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Connectivity
    {
        public int CountIslands(int[,] a)
        {
            int row = a.GetLength(0);
            int col = a.GetLength(1);
            bool[,] visited = new bool[row, col];

            int count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if(a[i, j] != 1 || visited[i,j]) continue;

                    count++;
                    DFS2D(a, i, j, visited);
                }
            }

            return count;
        }

        private void DFS2D(int[,] a, int r, int c, bool[,] visited)
        {
            visited[r,c] = true;
            Tuple<int, int>[] adjIdx =
            {
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(-1, 1),
            };

            foreach (var idx in adjIdx)
            {
                var nr = idx.Item1 + r;
                var nc = idx.Item2 + c;
                if (IsIndexValid(a, nr, nc))
                {
                    if(visited[nr,nc] || a[nr,nc] != 1) continue;
                    DFS2D(a, nr, nc, visited);
                }
            }
        }

        private bool IsIndexValid(int[,] a, int r, int c)
        {
            return (r >= 0) && (r < a.GetLength(0)) && (c >= 0) && (c < a.GetLength(1));

        }



        public int[] Dijkstra(int[,] grahp, int init) // This works only if the weight is non-negative
        {
            int v = grahp.GetLength(0);
            bool[] isInSpt = new bool[v];
            int[] pathLens = Enumerable.Range(1, v).Select(x => int.MaxValue).ToArray();            
            pathLens[init] = 0;

            int i = init;
            int min_i = i;
            int secMin_i = i;
            int minLen = int.MaxValue;
            int secMinLen = int.MaxValue;
            while (isInSpt.Any(x => x == false))
            {
                isInSpt[i] = true;
                int temp_min_i = 0;
                int temp_secMin_i = temp_min_i;
                for (int j = 0; j < v; j++)
                {
                    if(grahp[i,j] == 0) continue;
                    pathLens[j] = Math.Min(pathLens[j], pathLens[i] + grahp[i, j]);
              
                    if(pathLens[j] < pathLens[temp_min_i])
                    {
                        temp_secMin_i = temp_min_i;
                        temp_min_i = j;
                    }
                    minLen = pathLens[min_i];
                    secMinLen = pathLens[secMin_i];
                }

                if (pathLens[temp_min_i] < minLen)
                {
                    min_i = temp_min_i;
                    minLen = pathLens[min_i];
                    secMin_i = min_i;
                    min_i = j;
                }
                i = min_i;
                min_i = secMin_i;
            }
            return pathLens;
        }
    }
}
