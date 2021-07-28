using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HowSum
{
    class Program
    {
        static int HowSum(int targetSum, List<int> numbers)
        {
            if (targetSum < 0)
            {
                return 0;
            }
            else if (targetSum == 0)
            {
                return 1;
            }
            else
            {
                int totalWays = 0;
                foreach (int number in numbers)
                {
                    totalWays += HowSum(targetSum - number, numbers);
                }
                return totalWays;
            }
        }

        static int HowSumMemo(int targetSum, List<int> numbers, Dictionary<int, int> memo = null)
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
                memo.Add(targetSum, 0);
                return 0;
            }
            else if (targetSum == 0)
            {
                memo.Add(targetSum, 1);
                return 1;
            }
            else
            {
                int totalWays = 0;
                foreach (int number in numbers)
                {
                    totalWays += HowSumMemo(targetSum - number, numbers);
                }
                return totalWays;
            }
        }

        static void Main(string[] args)
        {
            Stopwatch sw;

            sw = Stopwatch.StartNew();
            int howSum = HowSum(7, new List<int> { 3, 4, 7, 5, 2, 1 });
            sw.Stop();
            Console.WriteLine(howSum + " " + sw.ElapsedTicks);

            sw = Stopwatch.StartNew();
            int howSumMemo = HowSumMemo(7, new List<int> { 3, 4, 7, 5, 2, 1 });
            sw.Stop();
            Console.WriteLine(howSumMemo + " " + sw.ElapsedTicks);
        }
    }
}
