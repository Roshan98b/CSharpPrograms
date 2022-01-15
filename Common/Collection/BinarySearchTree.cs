using System;
using System.Collections.Generic;

namespace Collection
{
    /// <summary>
    /// The Binary Search Tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class BinarySearchTree<T>
    {
        private Node<T> Root { get; set; }

        public BinarySearchTree()
        {
            this.Root = null;
        }

        public void Insert(T item)
        {
            this.Insert(this.Root, item);
        }

        public void DeleteTree()
        {
            this.DeleteTree(this.Root);
        }

        public bool IsInTree(T item)
        {
            return this.IsInTree(this.Root, item);
        }

        public int GetHeight()
        {
            return this.GetHeight(this.Root);
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
            this.DeleteValue(this.Root, item);
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

        private void Insert(Node<T> root, T item)
        {
            if (root == null)
            {
                root = new Node<T>(item);
            }
            else
            {
                if (Comparer<T>.Default.Compare(item, root.Item) > 0)
                {
                    this.Insert(root.Right, item);
                }
                else
                {
                    this.Insert(root.Left, item);
                }
            }
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

        private void DeleteTree(Node<T> root)
        {
            root = null; 
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
            else if (Comparer<T>.Default.Compare(item, root.Item) > 0)
            {
                return this.IsInTree(root.Right, item);
            } 
            else
            {
                return this.IsInTree(root.Left, item);
            }
        }

        private int GetHeight(Node<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                int left = this.GetHeight(root.Left);
                int right = this.GetHeight(root.Right);
                return left < right ? right + 1 : left + 1;
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

        private (Node<T>, Node<T>) GetMinNode(Node<T> root, Node<T> parent = null)
        {
            if (root == null)
            {
                throw new InvalidOperationException("No elements in the tree");
            }
            if (root.Left == null)
            {
                return (root, parent);
            }
            else
            {
                parent = root;
                return this.GetMinNode(root.Left, parent);
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

        private (Node<T>, Node<T>) Find(Node<T> root, T item, Node<T> parent = null)
        {
            if (root == null)
            {
                throw new InvalidOperationException($"No elements {item} in the tree");
            }
            else if (item.Equals(root.Item))
            {
                return (root, parent);
            }
            else if (Comparer<T>.Default.Compare(item, root.Item) >= 0)
            {
                parent = root;
                return this.Find(root.Right, item, parent);
            }
            else
            {
                parent = root;
                return this.Find(root.Left, item, parent);
            }
        }

        private void Delete(Node<T> root, Node<T> parent)
        {
            if(root.Left == null && root.Right == null)
            {
                if (root.Item.Equals(parent.Left.Item))
                {
                    parent.Left = null;
                } 
                else
                {
                    parent.Right = null;
                }
            }
            else if (root.Left == null)
            {
                if (root.Item.Equals(parent.Left.Item))
                {
                    parent.Left = root.Right;
                }
                else
                {
                    parent.Right = root.Right;
                }
            }
            else if (root.Right == null)
            {
                if (root.Item.Equals(parent.Left.Item))
                {
                    parent.Left = root.Left;
                }
                else
                {
                    parent.Right = root.Left;
                }
            }
            else
            {
                (Node<T> min, Node<T> minParent) = this.GetMinNode(root.Right, parent);
                root.Right.Item = min.Item;
                this.Delete(min, minParent);
            }
        }

        private void DeleteValue(Node<T> root, T item)
        {
            Node<T> parent;
            (root, parent) = this.Find(root, item, root);
            this.Delete(root, parent);
        }

        private void InOrderDisplay(Node<T> root)
        {
            if (root == null) return;
            else
            {
                this.InOrderDisplay(root.Left);
                Console.WriteLine($"{root.Item }");
                this.InOrderDisplay(root.Right);
            }
        }

        private void PreOrderDisplay(Node<T> root)
        {
            if (root == null) return;
            else
            {
                Console.WriteLine($"{root.Item }");
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
                Console.WriteLine($"{root.Item }");
            }
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
            this.Right = null;
            this.Left = null;
        }
    }
}
