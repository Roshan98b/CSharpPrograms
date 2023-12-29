namespace LongestOneSubArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().LongestSubarray(new int[] { 1, 1, 0, 0, 1, 1, 1, 0, 1 }));
        }

        public int LongestSubarray(int[] nums)
        {
            int i = 0;
            while (i < nums.Length && nums[i] != 1) i++;

            int j = i;
            int max = 0, zero = 0;
            while (j < nums.Length && zero < 2)
            {
                if (nums[j] == 0) zero++;
                if (nums[j] == 1) max++;
                j++;
            }

            if (zero == 0) return max - 1;
            else if (zero == 1) return max;
            else
            {
                int curr = max;
                i++;
                while (j < nums.Length)
                {
                    if (nums[i - 1] == 1) curr--;
                    if (nums[j] == 1) curr++;
                    if (curr < 1) curr = 0;
                    if (curr > max)
                    {
                        max = curr;
                    }
                    else
                    {
                        i++;
                    }
                    j++;
                }

                return max;
            }
        }
    }
}
