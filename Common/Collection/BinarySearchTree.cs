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

        public void Insert(Node<T> root, T item)
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

        public int GetNodeCount(Node<T> root)
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

        public void DeleteTree(Node<T> root)
        {
            root = null; 
        }

        public bool IsInTree(Node<T> root, T item)
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

        public int GetHeight(Node<T> root)
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

        public T GetMin(Node<T> root)
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

        public T GetMax(Node<T> root)
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

        public void DeleteValue(Node<T> root, T item)
        {
            Node<T> parent;
            (root, parent) = this.Find(root, item, root);
            Delete(root, parent);
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
