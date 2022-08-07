using Newtonsoft.Json;

namespace Permutations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var permutations = Permute(new int[] { 2, 3, 3, 2 });
            Console.WriteLine("Permutations are: ");
            Console.WriteLine(JsonConvert.SerializeObject(permutations));
        }        
        public static List<List<int>> Permute(int[] nums)
        {
            var permutations = Permute(nums.ToList());
            return permutations;
        }

        private static List<List<int>> Permute(List<int> nums)
        {
            if (nums.Count == 0)
            {
                return new List<List<int>> { new List<int> () };
            }
            else
            {
                var target = new List<List<int>>();
                foreach (var num in nums)
                {
                    // Removing the number
                    var slicedNum = new List<int>(nums);
                    var pos = 0;
                    for (int i = 0; i < slicedNum.Count; i++)
                    {
                        if (slicedNum[i] == num)
                        {
                            pos = i;
                            break; // Repeating numbers should be deleted only once
                        }
                    }
                    slicedNum.RemoveAt(pos);

                    var result = Permute(slicedNum);
                    target.AddRange( result.Select(x => { var y = new List<int> { num };  y.AddRange(x); return y; }) );
                }
                return target;
            }
        }

        private static bool IsValidTime(List<int> num)
        {
            int hours = num[0] * 10 + num[1];
            int minutes = num[2] * 10 + num[3];

            if (hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}