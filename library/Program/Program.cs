using System;
using System.Collections.Generic;

namespace LibraryApp
{
    public class Program
    {
        public static List<(string bookName, bool isBorrowed)> books = new List<(string, bool)>
        {
            ("Book 1", false),
            ("Book 2", false),
            ("Book 3", false),
            ("Book 4", false),
            ("Book 5", false)
        };

        public static HashSet<string> bookSet = new HashSet<string>(books.ConvertAll(b => b.bookName));
        public static List<string> borrowedBooks = new List<string>();

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nLibrary Menu:");
                Console.WriteLine("1. View Available Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("4. Search Book");
                Console.WriteLine("5. Borrow Book");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("7. View Borrowed Books");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        ViewAvailableBooks();
                        break;
                    case "2":
                        AddBook();
                        break;
                    case "3":
                        RemoveBook();
                        break;
                    case "4":
                        SearchBook();
                        break;
                    case "5":
                        BorrowBook();
                        break;
                    case "6":
                        ReturnBook();
                        break;
                    case "7":
                        ViewBorrowedBooks();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static void ViewAvailableBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("\nThe library is currently empty.");
            }
            else
            {
                Console.WriteLine("\nBooks in the library:");
                for (int i = 0; i < books.Count; i++)
                {
                    string status = books[i].isBorrowed ? " (Borrowed)" : "";
                    Console.WriteLine($"{i + 1}. {books[i].bookName}{status}");
                }
            }
        }

        public static void AddBook()
        {
            if (books.Count >= 5)
            {
                Console.WriteLine("The library cannot hold more than 5 books.");
                return;
            }

            Console.Write("\nEnter the name of the book to add: ");
            string bookName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(bookName) || !ContainsAlphanumeric(bookName))
            {
                Console.WriteLine("Book name must contain at least one alphanumeric character. Please try again.");
                return;
            }

            if (bookSet.Contains(bookName))
            {
                Console.WriteLine($"'{bookName}' already exists in the library.");
            }
            else
            {
                books.Add((bookName, false));
                bookSet.Add(bookName);
                Console.WriteLine($"'{bookName}' has been added to the library.");
            }
        }

        private static bool ContainsAlphanumeric(string str)
        {
            foreach (char c in str)
            {
                if (char.IsLetterOrDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public static void RemoveBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("\nThe library is currently empty.");
                return;
            }

            Console.Write("\nEnter the index of the book to remove: ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int index))
            {
                if (index > 0 && index <= books.Count)
                {
                    var book = books[index - 1];
                    if (book.isBorrowed)
                    {
                        Console.WriteLine($"'{book.bookName}' is currently borrowed and cannot be removed.");
                    }
                    else
                    {
                        books.RemoveAt(index - 1);
                        bookSet.Remove(book.bookName);
                        Console.WriteLine($"'{book.bookName}' has been removed from the library.");
                    }
                }
                else
                {
                    Console.WriteLine("Index out of range. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public static void PromptRemoveBook()
        {
            Console.Write("\nEnter the index of the book to remove: ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int index))
            {
                if (index > 0 && index <= books.Count)
                {
                    string bookName = books[index - 1].bookName;
                    books.RemoveAt(index - 1);
                    bookSet.Remove(bookName);
                    Console.WriteLine($"'{bookName}' has been removed from the library.");
                }
                else
                {
                    Console.WriteLine("Index out of range. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        public static void SearchBook()
        {
            Console.Write("\nEnter the name of the book to search: ");
            string bookName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Book name cannot be empty. Please try again.");
                return;
            }

            bool bookFound = false;
            foreach (var book in bookSet)
            {
                if (string.Equals(book, bookName, StringComparison.OrdinalIgnoreCase))
                {
                    bookFound = true;
                    break;
                }
            }

            if (bookFound)
            {
                Console.WriteLine($"'{bookName}' is available in the library.");
            }
            else
            {
                Console.WriteLine($"'{bookName}' is not available in the library.");
            }
        }

        public static void BorrowBook()
        {
            if (borrowedBooks.Count >= 3)
            {
                Console.WriteLine("You cannot borrow more than 3 books at a time.");
                return;
            }

            Console.Write("\nEnter the name of the book to borrow: ");
            string bookName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Book name cannot be empty. Please try again.");
                return;
            }

            var bookToBorrow = books.Find(b => string.Equals(b.bookName, bookName, StringComparison.OrdinalIgnoreCase) && !b.isBorrowed);
            if (bookToBorrow.bookName != null)
            {
                borrowedBooks.Add(bookToBorrow.bookName);
                books[books.IndexOf(bookToBorrow)] = (bookToBorrow.bookName, true);
                Console.WriteLine($"You have borrowed '{bookToBorrow.bookName}'.");
            }
            else
            {
                Console.WriteLine($"'{bookName}' is not available in the library or already borrowed.");
            }
        }

        public static void ReturnBook()
        {
            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("You have no borrowed books to return.");
                return;
            }

            Console.Write("\nEnter the name of the book to return: ");
            string bookName = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Book name cannot be empty. Please try again.");
                return;
            }

            string? bookToReturn = borrowedBooks.Find(b => b.Equals(bookName, StringComparison.OrdinalIgnoreCase));
            if (bookToReturn != null)
            {
                borrowedBooks.Remove(bookToReturn);
                var bookIndex = books.FindIndex(b => b.bookName.Equals(bookToReturn, StringComparison.OrdinalIgnoreCase));
                books[bookIndex] = (bookToReturn, false);
                Console.WriteLine($"You have returned '{bookToReturn}'.");
            }
            else
            {
                Console.WriteLine($"'{bookName}' is not in your borrowed books list.");
            }
        }

        public static void ViewBorrowedBooks()
        {
            if (borrowedBooks.Count == 0)
            {
                Console.WriteLine("\nYou have not borrowed any books.");
            }
            else
            {
                Console.WriteLine("\nBorrowed Books:");
                for (int i = 0; i < borrowedBooks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {borrowedBooks[i]}");
                }
            }
        }
    }
}
