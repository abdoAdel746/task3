using System.Transactions;
namespace task3
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availability { get; set; }

        public Book(string title, string author, string iSBN, bool availability = true)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Availability = availability;
        }
    }

    class Library
    {
        List<Book> books = new List<Book>();

        // Add a new book to the library
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"The book '{book.Title}' has been added successfully.");
        }

        // Search for a book by Title or Author
        public string SearchBook(string bookName)
        {
            foreach (var book in books)
            {
                if (book.Title.Contains(bookName) || book.Author.Contains(bookName))
                {
                    Console.WriteLine($"The book '{book.Title}' by {book.Author} is available.");
                    return $"The book '{book.Title}' by {book.Author} is available.";
                }
            }
            Console.WriteLine($"No book found matching '{bookName}'.");
            return $"No book found matching '{bookName}'.";
        }

        // Borrow a book by Title or Author
        public string BorrowBook(string bookName)
        {
            foreach (var book in books)
            {
                if (book.Title.Contains(bookName) || book.Author.Contains(bookName))
                {
                    if (book.Availability)
                    {
                        book.Availability = false; // Mark as borrowed
                        Console.WriteLine($"You have successfully borrowed '{book.Title}'.");
                        return $"You have successfully borrowed '{book.Title}'.";
                    }
                    else
                    {
                        Console.WriteLine($"Sorry, the book '{book.Title}' is currently borrowed.");
                        return $"Sorry, the book '{book.Title}' is currently borrowed.";
                    }
                }
            }
            Console.WriteLine($"The book '{bookName}' was not found in the library.");
            return $"The book '{bookName}' was not found in the library.";
        }

        // Return a book by Title or Author
        public string ReturnBook(string bookName)
        {
            foreach (var book in books)
            {
                if (book.Title.Contains(bookName) || book.Author.Contains(bookName))
                {
                    if (!book.Availability)
                    {
                        book.Availability = true; // Mark as available
                        Console.WriteLine($"Thank you for returning '{book.Title}'.");
                        return $"Thank you for returning '{book.Title}'.";
                    }
                    else
                    {
                        Console.WriteLine($"The book '{book.Title}' was not borrowed.");
                        return $"The book '{book.Title}' was not borrowed.";
                    }
                }
            }
            Console.WriteLine($"The book '{bookName}' is not found in our library collection.");
            return $"The book '{bookName}' is not found in our library collection.";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching for books
            Console.WriteLine("Searching for books...");
            library.SearchBook("Gatsby");
            library.SearchBook("Harry Potter"); // This book is not in the library

            // Borrowing books
            Console.WriteLine("\nBorrowing books...");
            library.BorrowBook("1984");
            library.BorrowBook("1984"); // Attempt to borrow again (already borrowed)
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("1984");
            library.ReturnBook("1984"); // Attempt to return again (already returned)
            library.ReturnBook("Harry Potter"); // This book is not in the library

            Console.ReadLine();
        }
    }
}
