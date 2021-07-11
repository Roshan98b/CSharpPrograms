using System;
using System.Collections.Generic;

namespace Sorting
{
    public class QuickSort
    {

        private static void _Swap(List<int> arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        private static int _Partition(List<int> arr, int low, int high)
        {
            int i = low - 1;
            int j = high + 1;
            int pivot = arr[(int)(low + high) / 2];
            while (true)
            {
                do
                {
                    i++;
                } while (arr[i] < pivot);
                do
                {
                    j--;
                } while (arr[j] > pivot);
                if (i >= j)
                {
                    return j;
                }
                _Swap(arr, i, j);
            }
        }

        public static void PrintArray(List<int> arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }

        public static void Sort(List<int> arr, int low, int high)
        {
            if (low < high)
            {
                int p = _Partition(arr, low, high);
                Sort(arr, low, p);
                Sort(arr, p + 1, high);
            }
        }
    }
}
