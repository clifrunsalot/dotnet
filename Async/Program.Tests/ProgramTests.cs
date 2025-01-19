using System;
using System.Threading.Tasks;
using Xunit;
using AsyncPlayground;

namespace Program.Tests
{
    public class ProgramTests
    {
        [Fact]
        public async Task TestDownloadDataAsync()
        {
            // Arrange
            var program = new AsyncPlayground.Program();
            var expectedOutput = new[]
            {
                "DownloadDataAsync: Start Downloading data...",
                "DownloadDataAsync: Downloading data 0...",
                "DownloadDataAsync: Downloading data 1...",
                "DownloadDataAsync: Downloading data 2...",
                "DownloadDataAsync: Downloading data 3...",
                "DownloadDataAsync: Downloading data 4...",
                "DownloadDataAsync: Stop Downloaded data..."
            };

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                await program.DownloadDataAsync();
                var result = sw.ToString().Trim().Split(Environment.NewLine);

                // Assert
                Assert.Equal(expectedOutput, result);
            }
        }

        [Fact]
        public async Task TestDownloadDataAsync2()
        {
            // Arrange
            var program = new AsyncPlayground.Program();
            var expectedOutput = new[]
            {
                "DownloadDataAsync2: Start Downloading data...",
                "DownloadDataAsync2: Downloading data 0...",
                "DownloadDataAsync2: Downloading data 1...",
                "DownloadDataAsync2: Downloading data 2...",
                "DownloadDataAsync2: Downloading data 3...",
                "DownloadDataAsync2: Downloading data 4...",
                "DownloadDataAsync2: Stop Downloaded data..."
            };

            // Act
            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                await program.DownloadDataAsync2();
                var result = sw.ToString().Trim().Split(Environment.NewLine);

                // Assert
                Assert.Equal(expectedOutput, result);
            }
        }
    }
}