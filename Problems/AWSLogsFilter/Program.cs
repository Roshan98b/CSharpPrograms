using Newtonsoft.Json;

namespace AWSLogsFilter
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> logs = new List<string>
            {
                "22 7 50",
                "22 7 20",
                "33 7 50",
                "22 7 30",
                "22 7 30"
            };

            int threshold = 2;

            List<string> result = ProcessLogs(logs, threshold);

            Console.WriteLine($"{JsonConvert.SerializeObject(result)}");
        }

        public static List<string> ProcessLogs(List<string> logs, int threshold)
        {
            var transactions = new Dictionary<string, int>();
            var finalList = new List<string>();

            foreach (var log in logs)
            {
                var splitLog = log.Split();
                if (transactions.ContainsKey(splitLog[0]))
                {
                    transactions[splitLog[0]] += 1;
                }
                else
                {
                    transactions[splitLog[0]] = 1;
                }
                if (!splitLog[0].Equals(splitLog[1]))
                {
                    if (transactions.ContainsKey(splitLog[1]))
                    {
                        transactions[splitLog[1]] += 1;
                    }
                    else
                    {
                        transactions[splitLog[1]] = 1;
                    }
                }
            }

            foreach (var pair in transactions)
            {
                if (pair.Value >= threshold)
                {
                    finalList.Add(pair.Key);
                }
            }

            finalList.Sort((x, y) => int.Parse(x).CompareTo(int.Parse(y)));

            return finalList;
        }

    }
}