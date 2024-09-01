namespace ProgrammingAnalystExercise
{
    public class Library
    {
        private readonly List<Book> books = new List<Book>();
        private readonly object _lock = new object();

        public Library()
        {
            books.Add(new Book("The Great Gatsby"));
            books.Add(new Book("1984"));
            books.Add(new Book("To Kill a Mockingbird"));
        }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                throw new ArgumentException("Book title cannot be empty or whitespace.");
            }

            lock (_lock)
            {
                books.Add(book);
                Log($"The book '{book.Title}' has been added to the Library.");
            }
        }

        public void BorrowBook(string title)
        {
            var book = FindBook(title);
            if (book != null)
            {
                book.Borrow();
            }
            else
            {
                Log($"The book '{title}' was not found in the library.");
            }
        }

        public void ReturnBook(string title)
        {
            var book = FindBook(title);
            if (book != null)
            {
                book.Return();
            }
            else
            {
                Log($"The book '{title}' was not found in the library.");
            }
        }

        public void RemoveBook(string title)
        {
            lock (_lock)
            {
                var book = FindBook(title);
                if (book != null)
                {
                    books.Remove(book);
                    Log($"The book '{title}' has been removed from the library.");
                }
                else
                {
                    Log($"The book '{title}' was not found in the library.");
                }
            }
        }

        private Book? FindBook(string title)
        {
            return books.FirstOrDefault(b => b.Title == title);
        }

        private void Log(string message)
        {
            // Implement logging logic here
            Console.WriteLine(message);
        }

        public IEnumerable<Book> GetBooks()
        {
            return books.AsReadOnly();
        }
    }



}
