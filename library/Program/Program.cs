using System;
using System.Collections.Generic;

namespace LibraryApp
{
    public class Program
    {
        public static List<string> books = new List<string>
        {
            "Book 1",
            "Book 2",
            "Book 3",
            "Book 4",
            "Book 5"
        };

        public static HashSet<string> bookSet = new HashSet<string>(books);

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nLibrary Menu:");
                Console.WriteLine("1. View Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(choice))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        ViewBooks();
                        break;
                    case "2":
                        AddBook();
                        break;
                    case "3":
                        RemoveBook();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static void ViewBooks()
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
                    Console.WriteLine($"{i + 1}. {books[i]}");
                }
            }
        }

        public static void AddBook()
        {
            Console.Write("\nEnter the name of the book to add: ");
            string bookName = Console.ReadLine();
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
                books.Add(bookName);
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
            PromptRemoveBook();
        }
        public static void PromptRemoveBook()
        {
            Console.Write("\nEnter the index of the book to remove: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index))
            {
                if (index > 0 && index <= books.Count)
                {
                    string bookName = books[index - 1];
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
    }
}