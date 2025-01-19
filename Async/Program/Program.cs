using System;
using System.Threading.Tasks;

namespace AsyncPlayground
{

    public class Program
    {

        public async Task DownloadDataAsync()
        {
            Console.WriteLine("DownloadDataAsync: Start Downloading data...");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DownloadDataAsync: Downloading data {i}...");
                await Task.Delay(1000);
            }
            Console.WriteLine("DownloadDataAsync: Stop Downloaded data...");
        }

        public async Task DownloadDataAsync2()
        {
            Console.WriteLine("DownloadDataAsync2:                          Start Downloading data...");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DownloadDataAsync2:                          Downloading data {i}...");
                await Task.Delay(500);
            }
            Console.WriteLine("DownloadDataAsync2:                          Stop Downloaded data...");
        }

        public static async Task Main(string[] args)
        {
            Program p = new Program();
            Task task1 = p.DownloadDataAsync();
            Task task2 = p.DownloadDataAsync2();
            await Task.WhenAll(task1, task2);

        }
    }

}