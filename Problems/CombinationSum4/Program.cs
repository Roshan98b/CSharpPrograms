namespace CombinationSum4
{
    using System;
    using System.Collections.Generic;

    public  class Program
    {
        static void Main(string[] args)
        {
            int sum = CombinationSum4(new[] { 1, 2, 3 }, 4);
            Console.WriteLine($"Total Sum = {sum}");
        }

        public static int CombinationSum4(int[] nums, int target)
        {
            return CombinationSum4WithMemo(nums, target, new Dictionary<int, int>());
        }

        private static int CombinationSum4WithMemo(int[] nums, int target, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(target))
            {
                return memo[target];
            }

            if (target < 0)
            {
                return 0;
            }
            else if (target == 0)
            {
                return 1;
            }
            else
            {
                int sum = 0;
                foreach (var num in nums)
                {
                    sum += CombinationSum4WithMemo(nums, target - num, memo);
                }
                memo.Add(target, sum);
                return sum;
            }
        }
    }
}