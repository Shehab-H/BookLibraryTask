namespace BookStoreTask.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public string BookISBN { get; private set; }
        public BookNotFoundException(string bookISBN) : base($"book with Isbn {bookISBN} was not found")
        {
            BookISBN = bookISBN;
        }
    }
}
