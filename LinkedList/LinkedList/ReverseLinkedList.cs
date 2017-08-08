using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ReverseLinkedList
    {
        public void ReverseDoubly<T>(LinkedList<T> list)
        {
            var current = list.Head;
            LinkedList<T>.Node<T> temp = null;

            while (current != null)
            {
                temp = current.prev;
                current.prev = current.next;
                current.next = temp;
                current = current.prev;
            }

            if (temp != null)
                list.Head = temp.prev;

        }

        public void ReverseSingly<T>(LinkedList<T> list)
        {
            var current = list.Head;
            LinkedList<T>.Node<T> prev = null;
            while (current != null)
            {
                var next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            list.Head = prev;
        }

        public void ReverseSinglyRecursively<T>(LinkedList<T> list)
        {
            LinkedList<T>.Node<T> head = null;
            var tail = RecursiveReverse(list.Head, ref head);
            tail.next = null;
            list.Head = head;
        }

        private LinkedList<T>.Node<T> RecursiveReverse<T>(LinkedList<T>.Node<T> node, ref LinkedList<T>.Node<T> head)
        {
            if (node == null)
                return null;

            if (node.next == null)
            {
                head = node;
                return node;
            }

            var next = RecursiveReverse<T>(node.next, ref head);
            next.next = node;
            return node;
        }
    }
}
