using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public struct NodeStruct<T>
        {
            public T data;
            public Node<T> next;
        }

        public class Node<T>
        {
            public T data;
            public Node<T> next;
            public Node<T> prev;

            public Node(T data)
            {
                this.data = data;
            }
        }

        public Node<T> Head { get; set; }

    }
}
