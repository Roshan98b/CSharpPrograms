using Newtonsoft.Json;

namespace Permutations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var permutations = Permute(new int[] { 1, 2, 3 });
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
                    var result = Permute(nums.Where(x => x != num).ToList());
                    target.AddRange( result.Select(x => { var y = new List<int> { num };  y.AddRange(x); return y; }) );
                }
                return target;
            }
        }
    }
}