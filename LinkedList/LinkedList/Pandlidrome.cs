using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Pandlidrome
    {
        public LinkedList<T>.Node<T> FindMiddleNode<T>(LinkedList<T> list, out bool isEven)
        {
            isEven = false;
            if (list.Head == null) return null;

            var last = list.Head;
            var middle = list.Head;
            while (last.next != null)
            {
                last = last.next;
                if (last.next == null)
                {
                    isEven = true;
                    break;
                }
                last = last.next;
                middle = middle.next;
            }
            return middle;
        }

        public bool IsPandlidrome<T>(LinkedList<T> list)
        {
            bool isEven;
            var middle = FindMiddleNode(list, out isEven);
            LinkedList<T>.Node<T> forward, backward;

            if (isEven)
            {
                forward = middle.next;
                backward = middle;
            }
            else
            {
                forward = middle.next;
                backward = middle.prev;
            }
            
            
            while (forward.data.Equals(backward.data))
            {
                forward = forward.next;
                backward = backward.prev;

                if(forward == null && backward == null)
                    return true;
            }
            return false;

        }
    
    }
}
