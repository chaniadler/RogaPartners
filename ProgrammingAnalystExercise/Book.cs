namespace ProgrammingAnalystExercise
{
       public class Book
    {
        public string Title { get; }// Made the setter for the Title property in the Book class private.
        public bool IsBorrowed { get; private set; }

        public Book(string title)
        {
            Title = title;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine($"The book '{Title}' has been checked out.");//Ensured consistent usage of string interpolation in Console.WriteLine statements.
            }
            else
            {
                Console.WriteLine($"The book '{Title}' is already checked out.");
            }
        }

        public void Return()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine($"The book '{Title}' has been returned.");
            }
            else
            {
                Console.WriteLine($"The book '{Title}' was not borrowed.");
            }
        }
    }


}
