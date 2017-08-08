using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>();
            var rdll = new ReverseLinkedList();
            list.Head.data = 1;
            list.Head.next = new LinkedList<int>.Node<int>(2)
                             {
                                 prev = list.Head
                             };
            list.Head.next.next = new LinkedList<int>.Node<int>(3)
                                  {
                                      prev = list.Head.next,
                                  };
            list.Head.next.next.next = new LinkedList<int>.Node<int>(4)
                                       {
                                           prev = list.Head.next.next
                                       };
            list.Head.next.next.next.next = new LinkedList<int>.Node<int>(5)
                                            {
                                                prev = list.Head.next.next.next
                                            }; 
            list.Head.next.next.next.next.next = new LinkedList<int>.Node<int>(6)
                                                 {
                                                     prev = list.Head.next.next.next.next,
                                                     next = null
                                                 };

            PrintList(list);
            rdll.ReverseDoubly(list);
            PrintList(list);
            rdll.ReverseSingly(list);
            PrintList(list);
            rdll.ReverseSinglyRecursively(list);
            PrintList(list);

            var nodeStruct = new LinkedList<int>.NodeStruct<int>();
            ModifyNodeStruct(nodeStruct); // struct is passed by value
            Console.Write(nodeStruct.data);

            Console.ReadKey();
        }

        public static void PrintList<T>(LinkedList<T> list)
        {
            Console.Write(list.Head.data);
            var current = list.Head.next;
            while (current != null)
            {
                Console.Write(" <--> {0}", current.data);
                current = current.next;
            }
            Console.WriteLine();
        }

        public static void ModifyNodeStruct(LinkedList<int>.NodeStruct<int> ns)
        {
            ns.data = 10;
            ns.next = new LinkedList<int>.Node<int>(11) {next = null, prev = new LinkedList<int>.Node<int>(10) };
        }
    }
}
