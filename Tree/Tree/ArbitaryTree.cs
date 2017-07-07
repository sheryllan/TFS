using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class ArbitaryTree<T>
    {
        public T Data { get; set; }
        public List<ArbitaryTree<T>> Children { get; set; }

        public ArbitaryTree() { }
        public ArbitaryTree(T data)
        {
            Data = data;
            Children = null;
        }

        public ArbitaryTree(T data, IEnumerable<ArbitaryTree<T>> children)
        {
            Data = data;
            Children = new List<ArbitaryTree<T>>(children);
        }

        public static int FindTreeHeight(ArbitaryTree<T> root)
        {
            if (root == null)
                return 0;
            if (root.Children == null)
                return 1;

            int[] children = new int[root.Children.Count];
            int i = 0;
            foreach (var c in root.Children)
            {
                children[i++] = 1 + FindTreeHeight(c);
            }
            return children.Max();
        }
    }
}
