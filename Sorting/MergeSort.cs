using System;
using System.Collections.Generic;

namespace Sorting
{
    public class MergeSort
    {
        private static void Merge(List<int> arr, int low, int mid, int high)
        {
            int lSize = mid + 1 - low;
            int rSize = high - mid;
            int i = 0, j = 0;
            int k = low;
            List<int> lArr = arr.GetRange(low, lSize);
            List<int> rArr = arr.GetRange(mid + 1, rSize);

            while (i < lSize && j < rSize)
            {
                if (lArr[i] <= rArr[j])
                {
                    arr[k] = lArr[i];
                    i++;
                    k++;
                }
                else
                {
                    arr[k] = rArr[j];
                    j++;
                    k++;
                }
            }
            while (i < lArr.Count)
            {
                arr[k] = lArr[i];
                i++;
                k++;
            }
            while (j < rArr.Count)
            {
                arr[k] = rArr[j];
                j++;
                k++;
            }
        }

        public static void Sort(List<int> arr, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
            else
            {
                int mid = (int)(low + high) / 2;
                Sort(arr, low, mid);
                Sort(arr, mid + 1, high);
                Merge(arr, low, mid, high);
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
    }
}
