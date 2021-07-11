using System;
using System.Collections.Generic;

namespace ArrayRotation
{
    class Program
    {

        static int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            } 
            else
            {
                return GCD(b, a % b);
            }
        }
        
        // Inplace array rotation
        // Time Complexity: O(size * pos)
        // Space Complexity: O(1)
        static void Rotation(List<int> arr, int size, int pos)
        {
            for (int i = 0; i < pos; i++)
            {
                int temp = arr[0];
                int j = 0;
                while (j < size-1)
                {
                    arr[j] = arr[(j + 1) % size];
                    j += 1;
                }
                arr[j] = temp;
            }
        }

        // Inplace array rotation using juggling algorithm
        // Time Complexity: O(size)
        // Space Complexity: O(1)
        static void RotationGCD(List<int> arr, int size, int pos)
        {
            int gcd_value = GCD(pos, size);
            for (int i = 0; i < gcd_value; i++)
            {
                int temp = arr[i];
                int j = i;
                while ((j + pos) % size != i)
                {
                    arr[j] = arr[(j + pos) % size];
                    j = (j + pos) % size;
                }
                arr[j] = temp;
            }
        }

        static void PrintArray(List<int> arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
        }

        static void Main()
        {
            List<int> arr = new();
            int pos, size;

            Console.Write("Enter size of array: ");
            size = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of rotations: ");
            pos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter elements: ");
            for (int i = 0; i < size; i++)
            {
                arr.Add(Convert.ToInt32(Console.ReadLine()));
            }

            RotationGCD(arr, size, pos);
            Rotation(arr, size, pos);
            PrintArray(arr);
        }
    }
}
