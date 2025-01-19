using System;
using System.Threading.Tasks;

namespace AsyncPlayground
{

    public class Program
    {

        public async Task DownloadDataAsync()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}   A-{i}");
                await Task.Delay(1000);
            }
        }

        public async Task DownloadDataAsync2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}               B-{i}");
                await Task.Delay(500);
            }
        }

        public async Task<string> CountingData()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}                         C-{i}");
                await Task.Delay(300);
            }
            // Ignore the return value
            return "CountingData:      Total data counted: 999";
        }

        public static async Task Main(string[] args)
        {
            Console.WriteLine("                           Download1  Download2  Counting");
            Program p = new Program();
            Task task1 = p.DownloadDataAsync();
            Task task2 = p.DownloadDataAsync2();
            Task<string> task3 = p.CountingData();
            await Task.WhenAll(task1, task2, task3);

        }
    }

}