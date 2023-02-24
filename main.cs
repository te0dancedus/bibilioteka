using System;
using System.Collections.Generic;

namespace Library
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsCheckedOut { get; set; }
        public string CheckedOutBy { get; set; }

        public Book(string title, string author, int publicationYear)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            IsCheckedOut = false;
            CheckedOutBy = "";
        }

        public void CheckOut(string patronName)
        {
            if (IsCheckedOut)
            {
                Console.WriteLine("This book is already checked out.");
            }
            else
            {
                IsCheckedOut = true;
                CheckedOutBy = patronName;
            }
        }

        public void CheckIn()
        {
            IsCheckedOut = false;
            CheckedOutBy = "";
        }

        public override string ToString()
        {
            return $"{Title} by {Author}, published in {PublicationYear}.";
        }
    }

    public class Library
    {
        public List<Book> Books { get; set; }

        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void DisplayBooks()
        {
            foreach (var book in Books)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public List<Book> GetAvailableBooks()
        {
            var availableBooks = new List<Book>();

            foreach (var book in Books)
            {
                if (!book.IsCheckedOut)
                {
                    availableBooks.Add(book);
                }
            }

            return availableBooks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();

            var book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925);
            var book2 = new Book("To Kill a Mockingbird", "Harper Lee", 1960);
            var book3 = new Book("1984", "George Orwell", 1949);

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            Console.WriteLine("Available books:");
            var availableBooks = library.GetAvailableBooks();
            foreach (var book in availableBooks)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine("Checking out The Great Gatsby...");
            book1.CheckOut("John Doe");

            Console.WriteLine("Available books:");
            availableBooks = library.GetAvailableBooks();
            foreach (var book in availableBooks)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
