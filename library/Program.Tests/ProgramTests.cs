using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace LibraryApp.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void TestViewAvailableBooks()
        {
            // Arrange
            var books = new List<string> { "Book 1", "Book 2", "Book 3", "Book 4", "Book 5" };
            var expectedOutput = "\nBooks in the library:\n1. Book 1\n2. Book 2\n3. Book 3\n4. Book 4\n5. Book 5\n";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Program.ViewAvailableBooks();

                // Assert
                var result = sw.ToString().Trim();
                Assert.Equal(expectedOutput.Trim(), result);
            }
        }

        [Fact]
        public void TestAddBook()
        {
            // Arrange
            var books = new List<string> { "Book 1", "Book 2", "Book 3", "Book 4", "Book 5" };
            var bookName = "Book 6";
            var expectedOutput = $"'{bookName}' has been added to the library.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(bookName))
                {
                    Console.SetIn(sr);

                    // Act
                    Program.AddBook();

                    // Assert
                    var result = sw.ToString().Trim();
                    Assert.Contains(expectedOutput, result);
                    Assert.Contains(bookName, Program.books);
                }
            }
        }

        [Fact]
        public void TestAddExistingBook()
        {
            // Arrange
            var books = new List<string> { "Book 1", "Book 2", "Book 3", "Book 4", "Book 5" };
            var bookName = "Book 1";
            var expectedOutput = $"'{bookName}' already exists in the library.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(bookName))
                {
                    Console.SetIn(sr);

                    // Act
                    Program.AddBook();

                    // Assert
                    var result = sw.ToString().Trim();
                    Assert.Contains(expectedOutput, result);
                }
            }
        }

        [Fact]
        public void TestRemoveBook()
        {
            // Arrange
            var books = new List<string> { "Book 1", "Book 2", "Book 3", "Book 4", "Book 5" };
            var bookIndex = "1";
            var expectedOutput = "'Book 1' has been removed from the library.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(bookIndex))
                {
                    Console.SetIn(sr);

                    // Act
                    Program.RemoveBook();

                    // Assert
                    var result = sw.ToString().Trim();
                    Assert.Contains(expectedOutput, result);
                    Assert.DoesNotContain("Book 1", Program.books);
                }
            }
        }

        [Fact]
        public void TestRemoveInvalidBook()
        {
            // Arrange
            var books = new List<string> { "Book 1", "Book 2", "Book 3", "Book 4", "Book 5" };
            var bookIndex = "10";
            var expectedOutput = "Index out of range. Please try again.";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader(bookIndex))
                {
                    Console.SetIn(sr);

                    // Act
                    Program.RemoveBook();

                    // Assert
                    var result = sw.ToString().Trim();
                    Assert.Contains(expectedOutput, result);
                }
            }
        }
    }
}