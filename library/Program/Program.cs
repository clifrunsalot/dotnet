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

                if (choice == null)
                {
                    Console.WriteLine("Input cannot be null. Please try again.");
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
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public static void ViewBooks()
        {
            Console.WriteLine("\nBooks in the library:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
        }

        public static void AddBook()
        {
            Console.Write("\nEnter the name of the book to add: ");
            string bookName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bookName))
            {
                Console.WriteLine("Book name cannot be empty. Please try again.");
                return;
            }

            if (books.Contains(bookName))
            {
                Console.WriteLine($"'{bookName}' already exists in the library.");
            }
            else
            {
                books.Add(bookName);
                Console.WriteLine($"'{bookName}' has been added to the library.");
                PromptRemoveBook(bookName);
            }
        }

        public static void RemoveBook()
        {
            PromptRemoveBook(null);
        }

        public static void PromptRemoveBook(string addedBookName)
        {
            ViewBooks();
            Console.Write("\nEnter the index of the book to remove: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= books.Count)
            {
                string bookName = books[index - 1];
                books.RemoveAt(index - 1);
                Console.WriteLine($"'{bookName}' has been removed from the library.");
            }
            else
            {
                if (addedBookName != null)
                {
                    Console.WriteLine($"Invalid index. '{addedBookName}' will be removed and the previous version of the library restored.");
                    books.Remove(addedBookName);
                }
                else
                {
                    Console.WriteLine("Invalid index. Please try again.");
                }
            }
        }
    }
}