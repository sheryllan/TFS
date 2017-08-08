using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new Graph<int>();
            g.AddVertex(0);
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            g.BFS(2); // 2 3 0 1
            g.DFS(0); // 0 2 3 1

            g.DFS_iter(0);

            Console.ReadKey();
        }
    }
}
