using Collection;
using System;
using System.Collections.Generic;

namespace DataStructures
{
    internal class HeapTest : IDataStructuresTest
    {
        private static readonly Heap<int> heap = new Heap<int>(10);

        public void Validate()
        {
            heap.Insert(35);
            heap.Insert(33);
            heap.Insert(42);
            heap.Insert(10);
            heap.Insert(14);
            heap.Insert(19);
            heap.Insert(27);
            heap.Insert(44);
            heap.Insert(26);
            heap.Insert(31);
            Display(heap);

            int[] sorted = heap.Sort(new int[] { 35, 33, 42, 10, 14, 19, 27, 44, 26, 31 });
            foreach (int element in sorted)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine("");

            heap.Delete(14);
            Display(heap);

            Console.WriteLine($"Poll : {heap.Poll()}");
            Console.WriteLine($"Poll : {heap.Poll()}");
            Display(heap);            
        }

        private static void Display<T>(Heap<T> heap)
        {
            foreach (T element in heap)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine("");
        }
    }
}
