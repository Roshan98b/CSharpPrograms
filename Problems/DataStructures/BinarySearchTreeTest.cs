using System;
using Collection;

namespace DataStructures
{
    internal class BinarySearchTreeTest : IDataStructuresTest
    {
        private static readonly BinarySearchTree<int> bst = new BinarySearchTree<int>();

        public void Validate()
        {
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(11);
            bst.Insert(233);
            bst.Insert(-4);
            bst.Insert(12);
            bst.Insert(123);
            bst.Insert(77);
            bst.Insert(300);
            bst.Insert(1);

            Console.WriteLine($"Height: {bst.GetHeight()}");

            Console.WriteLine("");
            Console.WriteLine("Inorder:");
            bst.InOrderDisplay();
            Console.WriteLine("Preorder:");
            bst.PreOrderDisplay();
            Console.WriteLine("Postrder:");
            bst.PostOrderDisplay();

            bst.DeleteValue(1);
            Console.WriteLine("");
            Console.WriteLine("Deleted 1");
            Console.WriteLine("Inorder:");
            bst.InOrderDisplay();
            Console.WriteLine("Preorder:");
            bst.PreOrderDisplay();

            bst.DeleteValue(12);
            Console.WriteLine("");
            Console.WriteLine("Deleted 12");
            Console.WriteLine("Inorder:");
            bst.InOrderDisplay();
            Console.WriteLine("Preorder:");
            bst.PreOrderDisplay();

            bst.DeleteValue(10);
            Console.WriteLine("");
            Console.WriteLine("Deleted 10");
            Console.WriteLine("Inorder:");
            bst.InOrderDisplay();
            Console.WriteLine("Preorder:");
            bst.PreOrderDisplay();

            bst.DeleteValue(13);
            Console.WriteLine("");
            Console.WriteLine("Deleted 13");
            Console.WriteLine("Inorder:");
            bst.InOrderDisplay();
            Console.WriteLine("Preorder:");
            bst.PreOrderDisplay();

            Console.WriteLine("");
            Console.WriteLine($"Min: {bst.GetMin()}");

            Console.WriteLine("");
            Console.WriteLine($"Max: {bst.GetMax()}");

            Console.WriteLine("");
            Console.WriteLine($"Height: {bst.GetHeight()}");

            Console.WriteLine("");
            Console.WriteLine($"Count: {bst.GetNodeCount()}");

            Console.WriteLine("");
            Console.WriteLine($"Is 6 in tree: {bst.IsInTree(6)}");

            Console.WriteLine("");
            Console.WriteLine($"Is 300 in tree: {bst.IsInTree(300)}");
        }
    }
}
