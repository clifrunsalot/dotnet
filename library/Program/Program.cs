using System;
using System.Collections.Generic;

/// <summary>
/// The Program class contains methods for managing a simple library system.
/// It allows users to view, add, remove, search, borrow, and return books.
/// </summary>
namespace LibraryApp
{
    public class Program
    {
        // List of books in the library
        private static List<(string bookName, bool isBorrowed)> books = new List<(string, bool)>
        {
            ("Book 1", false),
            ("Book 2", false),
            ("Book 3", false),
            ("Book 4", false),
            ("Book 5", false)
        };

        // Set of book names for quick lookup
        public static HashSet<string> bookSet = new HashSet<string>(Books.ConvertAll(b => b.bookName));

        // List of borrowed books
        public static List<string> borrowedBooks = new List<string>();

        /// <summary>
        /// Gets or sets the list of books in the library.
        /// </summary>
        /// <value>The list of books in the library.</value>
        /// <remarks>
        /// The list contains tuples with the book name and a boolean flag indicating whether the book is borrowed.
        /// </remarks>
        public static List<(global::System.String bookName, global::System.Boolean isBorrowed)> Books { get => books; set => books = value; }

        /// <summary>
        /// The Main method is the entry point of the program.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <remarks>
        /// The Main method is the entry point of the program.
        /// It displays a menu of options for users to interact with the library system.
        /// </remarks>
        public static void Main(string[] args)
        {
            // Display the library menu
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

                // Process user choice
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

        /// <summary>
        /// Displays the list of available books in the library.
        /// </summary>
        public static void ViewAvailableBooks()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("\nThe library is currently empty.");
            }
            else
            {
                Console.WriteLine("\nBooks in the library:");
                for (int i = 0; i < Books.Count; i++)
                {
                    string status = Books[i].isBorrowed ? " (Borrowed)" : "";
                    Console.WriteLine($"{i + 1}. {Books[i].bookName}{status}");
                }
            }
        }

        /// <summary>
        /// Adds a book to the library.
        /// </summary>
        public static void AddBook()
        {
            if (Books.Count >= 5)
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
                Books.Add((bookName, false));
                bookSet.Add(bookName);
                Console.WriteLine($"'{bookName}' has been added to the library.");
            }
        }

        /// <summary>
        /// Checks if a string contains at least one alphanumeric character.
        /// </summary>
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

        /// <summary>
        /// Removes a book from the library.
        /// </summary>
        public static void RemoveBook()
        {
            if (Books.Count == 0)
            {
                Console.WriteLine("\nThe library is currently empty.");
                return;
            }

            Console.Write("\nEnter the index of the book to remove: ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int index))
            {
                if (index > 0 && index <= Books.Count)
                {
                    var book = Books[index - 1];
                    if (book.isBorrowed)
                    {
                        Console.WriteLine($"'{book.bookName}' is currently borrowed and cannot be removed.");
                    }
                    else
                    {
                        Books.RemoveAt(index - 1);
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

        /// <summary>
        /// Searches for a book in the library.
        /// </summary>
        public static void PromptRemoveBook()
        {
            Console.Write("\nEnter the index of the book to remove: ");
            string input = Console.ReadLine() ?? "";
            if (int.TryParse(input, out int index))
            {
                if (index > 0 && index <= Books.Count)
                {
                    string bookName = Books[index - 1].bookName;
                    Books.RemoveAt(index - 1);
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

        /// <summary>
        /// Searches for a book in the library.
        /// </summary>
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

        /// <summary>
        /// Borrows a book from the library.
        /// </summary>
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

            var bookToBorrow = Books.Find(b => string.Equals(b.bookName, bookName, StringComparison.OrdinalIgnoreCase) && !b.isBorrowed);
            if (bookToBorrow.bookName != null)
            {
                borrowedBooks.Add(bookToBorrow.bookName);
                Books[Books.IndexOf(bookToBorrow)] = (bookToBorrow.bookName, true);
                Console.WriteLine($"You have borrowed '{bookToBorrow.bookName}'.");
            }
            else
            {
                Console.WriteLine($"'{bookName}' is not available in the library or already borrowed.");
            }
        }

        /// <summary>
        /// Returns a borrowed book to the library.
        /// </summary>
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
                var bookIndex = Books.FindIndex(b => b.bookName.Equals(bookToReturn, StringComparison.OrdinalIgnoreCase));
                Books[bookIndex] = (bookToReturn, false);
                Console.WriteLine($"You have returned '{bookToReturn}'.");
            }
            else
            {
                Console.WriteLine($"'{bookName}' is not in your borrowed books list.");
            }
        }

        /// <summary>
        /// Displays the list of borrowed books.
        /// </summary>
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
