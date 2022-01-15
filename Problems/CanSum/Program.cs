using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CanSum
{
    class Program
    {
        static bool CanSum(int targetSum, List<int> numbers)
        {
            if (targetSum < 0)
            {
                return false;
            }
            else if (targetSum == 0)
            {
                return true;
            }
            else
            {
                foreach (int number in numbers)
                {
                    if (CanSum(targetSum - number, numbers))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        static bool CanSumMemo(int targetSum, List<int> numbers, Dictionary<int, bool> memo = null)
        {
            if (memo == null)
            {
                memo = new();
            }
            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }
            if (targetSum < 0)
            {
                memo.Add(targetSum, false);
                return false;
            }
            else if (targetSum == 0)
            {
                memo.Add(targetSum, true);
                return true;
            }
            else
            {
                foreach (int number in numbers)
                {
                    if (CanSumMemo(targetSum - number, numbers))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        static void Main(string[] args)
        {
            Stopwatch sw;

            sw = Stopwatch.StartNew();
            bool canSum = CanSum(7, new List<int> { 2, 4 });
            sw.Stop();
            Console.WriteLine(canSum + " " + sw.ElapsedTicks);

            sw = Stopwatch.StartNew();
            bool canSumMemo = CanSumMemo(7, new List<int> { 2, 4 });
            sw.Stop();
            Console.WriteLine(canSumMemo + " " + sw.ElapsedTicks);
        }
    }
}
