using System;
using System.Collections.Generic;

namespace Collection
{
    /// <summary>
    /// The Binary Search Tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinarySearchTree<T>
    {
        private Node<T> Root { get; set; }

        private List<T> order = new List<T>();

        public BinarySearchTree()
        {
            this.Root = null;
        }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void DeleteTree()
        {
            this.Root = null;
        }

        public bool IsInTree(T item)
        {
            return this.IsInTree(this.Root, item);
        }

        public int GetHeight()
        {
            return this.GetHeight(this.Root);
        }

        public int GetNodeCount()
        {
            return this.GetNodeCount(this.Root);
        }

        public T GetMin()
        {
            return this.GetMin(this.Root);
        }

        public T GetMax()
        {
            return this.GetMax(this.Root);
        }

        public void DeleteValue(T item)
        {
            this.Root = this.DeleteValue(this.Root, item);
        }

        public void InOrderDisplay()
        {
            this.InOrderDisplay(this.Root);
            Console.WriteLine("");
        }

        public void PreOrderDisplay()
        {
            this.PreOrderDisplay(this.Root);
            Console.WriteLine("");
        }

        public void PostOrderDisplay()
        {
            this.PostOrderDisplay(this.Root);
            Console.WriteLine("");
        }

        public bool IsValidBST()
        {
            return IsValidBST(this.Root);
        }

        private Node<T> Insert(Node<T> root, T item)
        {
            if (root == null)
            {
                root = new Node<T>(item);
            }
            else
            {
                if (Comparer<T>.Default.Compare(item, root.Item) < 0)
                {
                    root.Left =  this.Insert(root.Left, item); 
                }
                else
                {
                    root.Right = this.Insert(root.Right, item);
                }
            }
            return root;
        }

        private int GetNodeCount(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            } 
            else
            {
                return this.GetNodeCount(root.Left) + this.GetNodeCount(root.Right) + 1;
            }
        }

        private bool IsInTree(Node<T> root, T item)
        {
            if(root == null)
            {
                return false;
            }
            else if (item.Equals(root.Item)) 
            {
                return true;
            }
            else if (Comparer<T>.Default.Compare(item, root.Item) < 0)
            {
                return this.IsInTree(root.Left, item);
            } 
            else
            {
                return this.IsInTree(root.Right, item);
            }
        }

        private int GetHeight(Node<T> root)
        {
            if (root == null)
            {
                return -1;
            }
            else
            {
                int left = this.GetHeight(root.Left);
                int right = this.GetHeight(root.Right);
                return (left < right ? right : left) + 1;
            }
        }

        private T GetMin(Node<T> root)
        {
            if (root == null)
            {
                throw new InvalidOperationException("No elements in the tree");
            }
            if (root.Left == null)
            {
                return root.Item;
            }
            else
            {
                return this.GetMin(root.Left);
            }
        }

        private T GetMax(Node<T> root)
        {
            if (root == null)
            {
                throw new InvalidOperationException("No elements in the tree");
            }
            if (root.Right == null)
            {
                return root.Item;
            }
            else
            {
                return this.GetMax(root.Right);
            }
        }

        private Node<T> DeleteValue(Node<T> root, T item)
        {
            if (root == null)
            {
                return root;
            }
            if (Comparer<T>.Default.Compare(item, root.Item) < 0)
            {
                root.Left = this.DeleteValue(root.Left, item);
            }
            else if (Comparer<T>.Default.Compare(item, root.Item) > 0)
            {
                root.Right = this.DeleteValue(root.Right, item);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                else
                {
                    root.Item = this.GetMin(root.Right);
                    root.Right = this.DeleteValue(root.Right, root.Item);
                }
            }
            return root;
        }

        private void InOrderDisplay(Node<T> root)
        {
            if (root == null) return;
            else
            {
                this.InOrderDisplay(root.Left);
                Console.Write($"{root.Item} ");
                this.InOrderDisplay(root.Right);
            }
        }

        private void PreOrderDisplay(Node<T> root)
        {
            if (root == null) return;
            else
            {
                Console.Write($"{root.Item} ");
                this.PreOrderDisplay(root.Left);
                this.PreOrderDisplay(root.Right);
            }
        }

        private void PostOrderDisplay(Node<T> root)
        {
            if (root == null) return;
            else
            {
                this.PostOrderDisplay(root.Left);
                this.PostOrderDisplay(root.Right);
                Console.Write($"{root.Item} ");
            }
        }

        private bool IsValidBST(Node<T> root)
        {
            if (root == null)
            {
                return true;
            }
            InorderAdd(root);
            if (order.Count >= 2)
            {
                for (int i = 1; i < order.Count; i++)
                {
                    if (Comparer<T>.Default.Compare(order[i - 1], order[i]) >= 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        private void InorderAdd(Node<T> root)
        {
            if (root == null)
            {
                return;
            }
            InorderAdd(root.Left);
            order.Add(root.Item);
            InorderAdd(root.Right);
        }

    }

    /// <summary>
    /// The Node class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Node<T>
    {
        public T Item { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node(T item)
        {
            this.Item = item;
        }
    }
}
