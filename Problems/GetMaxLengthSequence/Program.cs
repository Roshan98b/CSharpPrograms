using System.Collections.Generic;
using System.Linq;

namespace GetMaxLengthSequence
{
    internal class Program
    {
        /*
        input = [5 7 4 -4 1 10 4 5 8 9 3]
        output = integer - max length of set of numbers which are in increasing order. Move from left to right

        Iteration:
        -4 1 4 5 8 9
        Output = 6

                                    I
                            5                                               7
                    7           9           10          8   9           
            9   10  8   9    10  8   9      8   9       9
        */

        static void Main(string[] args)
        {
            Console.WriteLine($"Count: {GetMaxLengthSequence(new List<int> {5, 7, 4, -4, 1, 10, 4, 5, 8, 9, 3}, new Dictionary<int, int>())}");
        }

        public static int GetMaxLengthSequence(List<int> input, Dictionary<int, int> map)
        {
            if (input.Count == 1)
            {
                return 1;
            }

            int prev = input[0];
            var branches = new List<int>();
            int count = 1;
            foreach (int num in input)
            {
                if (map.ContainsKey(num))
                {
                    count = map[num];
                }

                if (num > prev)
                {
                    branches.Add(input[count]);
                    prev = num;
                }

                count = GetMaxLengthSequence(branches, map);
            }


            return count;
        }

        public static int GetMaxLengthSequence(int[] input)
        {
            int maxCount = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int prev = input[i];
                int count = 1;
                var branch = new List<int>
                {
                    prev
                };

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] > prev) branch.Add(input[j]);
                }

                if (count > maxCount) maxCount = count;
            }

            return maxCount;
        }
    }
}
