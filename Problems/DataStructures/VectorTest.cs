using System;
using System.Collections.Generic;
using System.Linq;
using Collection;

namespace DataStructures
{
    internal class VectorTest: IDataStructuresTest
    {
        private static readonly Vector<int> vector = new Vector<int>();
        
        public void Validate()
        {
            Console.WriteLine($"Size: {vector.Size}");
            Console.WriteLine($"Capacity: {vector.Capacity}");

            for (int i = 0; i < 16; i++)
            {
                vector.Push(i);
            }
            Display(vector);

            vector.Push(16);
            Display(vector);

            Console.WriteLine($"Poped element: {vector.Pop()}");
            Console.WriteLine($"Poped element: {vector.Pop()}");
            Display(vector);

            vector.Prepend(3);
            Display(vector);

            for (int i = 0; i < 10; i += 2)
            {
                vector.Insert(3, i);
            }
            Display(vector);

            vector.Remove(3);
            vector.Remove(0);
            vector.Remove(12);
            vector.Remove(14);
            Display(vector);

            for (int i = 0; i < 5; i += 2)
            {
                vector.Delete(i);
            }
            vector.Delete(2);
            Display(vector);
            Console.WriteLine($"Element 4 found at: {vector.Find(4)}");
            Console.WriteLine($"Element at position 4 : {vector.At(3)}");
        }

        private static void Display<T>(Vector<T> vector)
        {
            foreach (T element in vector)
            {
                Console.Write($"{element} ");                
            }
            Console.WriteLine("");
        }
    }
}
