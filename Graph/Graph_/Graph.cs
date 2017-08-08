using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public class Graph<T>
    {
        private Dictionary<T, bool> _visited;
        public int V => Vertices.Count;

        public List<Vertex<T>> Vertices { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        public void AddEdge(T src, T dest)
        {
            var srcVtx = Vertices.Find(x => src.Equals(x.Content));
            var destVtx = Vertices.Find(x => dest.Equals(x.Content));

            srcVtx = srcVtx ?? AddVertex(src);
            destVtx = destVtx ?? AddVertex(dest);
            var destNode = new Vertex<T>.Node(destVtx) {next = srcVtx.Edges.Head};
            srcVtx.Edges.Head = destNode;
        }

        public Vertex<T> AddVertex(T v)
        {
            var vertex = new Vertex<T>(v);
            Vertices.Add(vertex);
            return vertex;
        }

        public void BFS(T s)
        {
            _visited = Vertices.ToDictionary(x => x.Content, x => false);

            var vtx = Vertices.Find(v => v.Content.Equals(s));
            if(vtx == null) return;

            var queue = new Queue<Vertex<T>>();
            queue.Enqueue(vtx);
            while (queue.Count > 0)
            {
                vtx = queue.Dequeue();
                Console.Write(vtx.Content + " ");
                _visited[vtx.Content] = true;
                var adj = vtx.Edges.Head;
                while (adj != null)
                {
                    if (!_visited[adj.vertex.Content])
                    {
                        queue.Enqueue(adj.vertex);
                    }
                    adj = adj.next;
                }
            }
            Console.WriteLine();
        }

        public void DFS()
        {
            _visited = Vertices.ToDictionary(x => x.Content, x => false);
            foreach (var v in Vertices)
            {
                if(!_visited[v.Content])
                    DFSUtility(v);
            }
            Console.WriteLine();
        }

        public void DFS(T s)
        {
            _visited = Vertices.ToDictionary(x => x.Content, x => false);
            DFSUtility(Vertices.Find(x => s.Equals(x.Content)));
            Console.WriteLine();
        }

        private void DFSUtility(Vertex<T> v)
        {
            if (v == null) return;
            if (!_visited[v.Content])
            {
                Console.Write(v.Content +  " ");
                _visited[v.Content] = true;
                var adj = v.Edges.Head;
                while (adj != null)
                {
                    DFSUtility(adj.vertex);
                    adj = adj.next;
                }
            }
        }

        public void DFS_iter(T s)
        {
            _visited = Vertices.ToDictionary(x => x.Content, x => false);
            var vtx = Vertices.Find(v => v.Content.Equals(s));
            if(vtx == null) return;
            Console.Write(vtx.Content + " ");
            _visited[vtx.Content] = true;
            var adj = vtx.Edges.Head;
            var stack = new Stack<Vertex<T>.Node>();
            var done = false;
            while (!done)
            {
                if (adj != null)
                {
                    if (!_visited[adj.vertex.Content])
                    {
                        Console.Write(adj.vertex.Content + " ");
                        _visited[adj.vertex.Content] = true;
                        stack.Push(adj);
                        adj = adj.vertex.Edges.Head;
                    }
                    else
                    {
                        adj = adj.next;
                    }
                }
                else
                {
                    if (stack.Count <= 0)
                        done = true;
                    else
                    {
                        adj = stack.Pop();
                        adj = adj.next;
                    }
                }
                
            }
            Console.WriteLine();
        }    
    }
}
