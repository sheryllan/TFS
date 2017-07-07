using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Node<T> 
    {
        public T Key { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T key)
        {
            this.Key = key;
            Left = Right = null;
        }
    }

    public class Program
    {
        public static Node<int> Insert(Node<int> node, int data)
        {
            var newNode = new Node<int>(data);
            if (node == null)
                return newNode;

            if (data <= node.Key)
                node.Left = Insert(node.Left, data);
            else //if(data >= node.key)
                node.Right = Insert(node.Right, data);

            return node;
        }

        public static void Inorder(Node<int> n)
        {
            if (n != null)
            {
                Inorder(n.Left);
                Console.WriteLine(n.Key);
                Inorder(n.Right);
            }
        }

        public static Node<int> Search(Node<int> node, int data)
        {
            if (node == null || data == node.Key)
                return node;

            if (data < node.Key)
                return Search(node.Left, data);

            return Search(node.Right, data);

        }

        public static Stack<Node<int>> InoderStack(Node<int> node, int data)
        {
            var stack = new Stack<Node<int>>();
            while (node != null)
            {
                stack.Push(node);
                if (data == node.Key)
                    break;
                else if (data < node.Key)
                    node = node.Left;
                else
                    node = node.Right;
            }
            return stack;
        }

        public static Node<int> NextInorderNode(Node<int> node)
        {
            var parent = node;
            while (node.Left != null)
            {
                parent = node;
                node = node.Left;
            }
            parent.Left = null;
            return node;
        }

        public static Node<int> Delete(Node<int> root, int data)
        {
            var stack = InoderStack(root, data);
            Node<int> nodeD = null;

            if (stack.Count > 0)
                nodeD = stack.Pop();
            if (nodeD == null)
                return root;

            if (nodeD.Left == null && nodeD.Right == null)
            {
                nodeD = null;
            }
                
            else if(nodeD.Left == null && nodeD.Right != null)
            {
                nodeD = nodeD.Right;
            }
            else if(nodeD.Left != null && nodeD.Right == null)
            {
                nodeD = nodeD.Left;
            }
            else
            {
                var minNode = NextInorderNode(nodeD);
                minNode.Left = nodeD.Left;
                minNode.Right = nodeD.Right;
                nodeD = minNode;
            }

            var parent = stack.Count > 0 ? stack.Pop() : null;
            if (parent != null)
            {
                if (parent.Key > nodeD.Key)
                    parent.Left = nodeD;
                else
                    parent.Right = nodeD;
            }

            return parent == null ? nodeD : root;
        }

        static void Main(string[] args)
        {
            Node<int> root = null;
            root = Insert(root, 50);
            root = Insert(root, 30);
            root = Insert(root, 20);
            root = Insert(root, 40);
            root = Insert(root, 70);
            root = Insert(root, 60);
            root = Insert(root, 80);

            Console.WriteLine("Inorder traversal of the given tree:");
            Inorder(root);

            root = Delete(root, 70);
            Console.WriteLine("Inorder traversal of the given tree after deletion:");
            Inorder(root);

            Console.ReadKey();
        }
    }
}
