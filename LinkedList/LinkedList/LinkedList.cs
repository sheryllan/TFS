using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public class Node<T>
        {
            public T data;
            public Node<T> next;
            public Node<T> prev;
        }

        public LinkedList()
        {
            Head = new Node<T>();
        }

        public Node<T> Head { get; set; }

    }
}
