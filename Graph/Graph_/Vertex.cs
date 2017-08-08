using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_
{
    public class Vertex<T>
    {
        public T Content { get; set; }
        public AdjList Edges { get; set; }

        public Vertex(T content)
        {
            Content = content;
            Edges = new AdjList();
        }

        public class AdjList
        {
            public Node Head { get; set; }
            
        }

        public class Node
        {
            public Vertex<T> vertex;
            public Node next;

            public Node(Vertex<T> v)
            {
                vertex = v;
            }
        }

    }
}
