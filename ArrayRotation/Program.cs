using System;
using System.Collections.Generic;

namespace ArrayRotation
{
    class Program
    {

        static int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            } 
            else
            {
                return gcd(b, a % b);
            }
        }

        static void arrayRotation(List<int> arr, int size, int dir, int pos)
        {
            int gcd_value = gcd(size, pos);
            for (int i = 0; i < gcd_value; i++)
            {
                int temp = arr[i];
                int j = i;
                while (true)
                {
                    int k = j + pos;
                    
                    arr[j] = arr[(j + pos) % size];
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> arr = new List<int>();
            int dir, pos, size;

            Console.Write("Enter size of array: ");
            size = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter direction for rotation: ");
            dir = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number of rotations: ");
            pos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter elements: ");
            for (int i = 0; i < size; i++)
            {
                arr.Add(Convert.ToInt32(Console.ReadLine()));
            }

            arrayRotation(arr, size, dir, pos);

        }
    }
}
