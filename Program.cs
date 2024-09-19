using System.Transactions;

namespace task3
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Availabilty { get; set; }

        public Book(string title, string author, string iSBN, bool availabilty=true)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            Availabilty = availabilty;
        }
    }
    class Library
    {
        List<Book> books = new List<Book>();
        public void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine("the book is added succesfully");

        }

        public string SearchBook(string book)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author.Contains(book) || books[i].Title.Contains(book))
                {
                    found = true;
                    
                }
            }
            if (found)
            {
                Console.WriteLine("book is found");

                return "book is found";
            }
            else
            {
                Console.WriteLine("not found");

                return "not found";
            }
        }

        public string BorrowBook(string book)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author.Contains(book) || books[i].Title.Contains(book))
                {
                    if (books[i].Availabilty)
                    {
                        found = true;
                    }
                }
            }
            if (found)
            {
                Console.WriteLine("you can borrow the book");
                return "you can borrow the book";
            }
            else
            {
                Console.WriteLine("you can't borrow the book");
                return "you can't borrow the book";
            }
        }

        public string ReturnBook(string book)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author.Contains(book) || books[i].Title.Contains(book))
                {
                  
                        found = true;
                    
                }
            }
            if (found)
            {
                Console.WriteLine("the book is returned");
                return "the book is returned";
            }
            else
            {
                Console.WriteLine("the book not found");

                return "the book not found";
            }
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

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.SearchBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}
