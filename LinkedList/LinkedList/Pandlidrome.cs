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
            bool isPandlidrome = true;
            var middle = FindMiddleNode(list, out isEven);
            if (middle == null) return false;

            var backward = middle;
            var forward = isEven ? middle.next : middle;
            
            while (backward != null && forward != null) 
            {
                if (forward.data.Equals(backward.data))
                    // The equality comparison should be provided by type T not LinkedList
                    // A strongly typed equality check would be invoked if T implements IEquatable<T>
                {
                    forward = forward.next;
                    backward = backward.prev;
                }
                else
                {
                    isPandlidrome = false;
                    break;
                }
                
            }
            return isPandlidrome;

        }
    
    }
}
