using System;
using System.Collections.Generic;

namespace SortedSquares
{
    internal class Program
    {
        private static int BinarySearch(int[] nums)
        {
            int low = 0;
            int high = nums.Length - 1;
            while (low <= high)
            {
                int mid = low + ((high - low) / 2);
                if (nums[mid] < 0)
                {
                    low = mid + 1;
                } 
                else
                {
                    high = mid - 1;
                }
            }
            return low;
        }

        private static int[] SortedSquares(int[] nums)
        {
            List<int> result = new List<int>();
            int pos = BinarySearch(nums);

            if (pos == nums.Length)
            {
                pos--;
            }

            int i = pos - 1;
            int j = pos;

            while (i >= 0 && j <= nums.Length - 1)
            {
                if (-nums[i] < nums[j])
                {
                    result.Add(-nums[i] * -nums[i]);
                    i--;
                }
                else
                {
                    result.Add(nums[j] * nums[j]);
                    j++;
                }
            }

            while (i >= 0)
            {
                result.Add(-nums[i] * -nums[i]);
                i--;
            }

            while (j <= nums.Length - 1)
            {
                result.Add(nums[j] * nums[j]);
                j++;
            }

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            int[] arr1 = new int[3] { -1, 2, 2 };
            int[] arr2 = new int[9] { -7, 2, 3, 4, 11, 12, 16, 25, 50 };

            SortedSquares(arr1);
        }
    }
}
