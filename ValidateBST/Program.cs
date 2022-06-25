using System;
using Collection;

namespace ValidateBST
{
    internal class Program
    {
        private static readonly BinarySearchTree<int> bst = new BinarySearchTree<int>();

        static void Main(string[] args)
        {
            bst.Insert(2);
            bst.Insert(1);
            bst.Insert(3);

            Console.WriteLine($"Is Valid BST : {bst.IsValidBST()}");
        }
    }
}
