using System.Text;

namespace ReverseSubstringCompare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Count: {countNumWays("amazon", 2)}");
        }

        public static int countNumWays(string s, int k)
        {
            int count = 0;

            if (k == 1) return 0;

            for (int i = 0; i <= s.Length - k; i++)
            {
                var reverseSubstring = new StringBuilder(s);

                for (int x = i, y = i+k -1; x <= y; x++, y--)
                {
                    char temp = reverseSubstring[x];
                    reverseSubstring[x] = reverseSubstring[y];
                    reverseSubstring[y] = temp;
                }

                for (int l = 0; l < s.Length; l++)
                {
                    if (reverseSubstring[l] != s[l])
                    {
                        if (reverseSubstring[l] < s[l]) count++;
                        break;
                    }
                }

            }

            return count;
        }
    }
}