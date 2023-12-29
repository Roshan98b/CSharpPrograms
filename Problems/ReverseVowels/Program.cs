using System.Text;

namespace ReverseVowels
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Program().ReverseVowels("Hello, World!"));
        }

        public string ReverseVowels(string s)
        {
            var vowels = new List<char>() { 'a', 'A', 'E', 'e', 'i', 'I', 'O', 'o', 'u', 'U' };
            var reversedString = new StringBuilder(s);

            int i = 0, j = s.Length - 1;
            while (i < j) 
            {
                bool isFirstVowel = vowels.Contains(reversedString[i]);
                bool isLastVowel = vowels.Contains(reversedString[j]);

                if (!isFirstVowel) i++;
                if (!isLastVowel) j--;

                if (isFirstVowel && isLastVowel)
                {
                    char temp = reversedString[i];
                    reversedString[i] = reversedString[j];
                    reversedString[j] = temp;
                    i++;
                    j--;
                }
            }

            return reversedString.ToString();
        }
    }
}


