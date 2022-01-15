using System;
using Collection;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Program.VectorTest();
        }

        static void VectorTest()
        {
            Vector<int> vector = new Vector<int>();

            Console.WriteLine($"Size: {vector.Size}");
            Console.WriteLine($"Capacity: {vector.Capacity}");

            for (int i = 0; i < 16; i++)
            {
                vector.Push(i);
            }
            Program.Display(vector);

            vector.Push(16);
            Program.Display(vector);

            Console.WriteLine($"Poped element: {vector.Pop()}");
            Console.WriteLine($"Poped element: {vector.Pop()}");
            Program.Display(vector);

            vector.Prepend(3);
            Program.Display(vector);

            for (int i = 0; i < 10; i += 2)
            {
                vector.Insert(3, i);
            }
            Program.Display(vector);

            vector.Remove(3);
            vector.Remove(0);
            vector.Remove(12);
            vector.Remove(14);
            Program.Display(vector);

            for (int i = 0; i < 5; i += 2)
            {
                vector.Delete(i);
            }
            vector.Delete(2);
            Program.Display(vector);
            Console.WriteLine($"Element 4 found at: {vector.Find(4)}");
            Console.WriteLine($"Element at position 4 : {vector.At(3)}");
        }

        static void Display<T>(Vector<T> vector)
        {
            if (vector.Size == 0) Console.WriteLine("No elements to Display");
            int i = 0;
            foreach (T element in vector)
            {
                if (i == vector.Size) break;
                Console.Write($"{element} ");
                i++;
            }
            Console.WriteLine("");
        }
    }
}
