namespace FraudActivity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Notification sent : {FraudActivity(new int[] {10, 20, 30, 40, 50}, 3)}");
        }

        private static int FraudActivity(int[] expenditure, int d)
        {
            // Retrun count

            // Scan d elements and sort and find median
            var medianList = new List<int>();
            for (int i = 0; i < d; i++)
            {
                medianList.Add(expenditure[i]);
            }
            medianList.Sort();
            int median = GetMedian(medianList, d);

            // Scan d to n elements, update the window elements, sort anf find median => Increment count based on requirement
            int notificationCount = 0;
            for (int i = d; i < expenditure.Length; i++)
            {
                if (expenditure[d] >= 2 * median) notificationCount++;

            }

            return notificationCount;
        }

        private static int GetMedian(List<int> medianList, int d)
        {
            return 0;
        }
    }
}
