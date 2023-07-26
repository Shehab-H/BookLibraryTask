namespace BookStoreTask.Exceptions
{
    public class NoAvailableCopiesException : Exception
    {
        public NoAvailableCopiesException() : base("there is no copies available for this book")
        {

        }
    }
}
