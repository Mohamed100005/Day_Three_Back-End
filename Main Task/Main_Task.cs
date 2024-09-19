namespace Main_Task
{
    class Book
    {
        public string Title { get; }
        public string Author { get; }
        string Isbn { get; }
        public bool Availability { get; set; }

        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Availability = true;
        }
    }
    class Library
    {
        public List<Book> books = new();
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            if (books == null)
                return;
            else
                books.Remove(book);
        }
        public bool SearchBook(string bookTitle = " ", string bookAuthur = " ")
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (bookTitle == books[i].Title || bookAuthur == books[i].Author)
                {
                    Console.WriteLine("Book Exists");
                    return true;
                }
            }
            Console.WriteLine("Book Not Exists");
            return false;
        }
        public bool BorrowBook(string bookTitle)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == bookTitle)
                {
                    books[i].Availability = false;
                    Console.WriteLine("Borrowed");
                    return true;
                }
            }
            Console.WriteLine("This book is not available");
            return false;
        }

        public bool ReturnBook(string bookTitle)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title == bookTitle)
                {
                    books[i].Availability = true;
                    Console.WriteLine("Returned");
                    return true;

                }
            }
            Console.WriteLine("This book is not available");
            return false;
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
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            // Searching book
            Console.WriteLine("\nSearching books...");
            library.SearchBook(bookTitle: "The Great Gatsby");
            library.SearchBook(bookAuthur: "F. Scott Fitzgerald");
            library.SearchBook(bookTitle: "Harry Potter"); // This book is not exists
        }
    }
}
