namespace BookStoreTask.Interfaces
{
    public interface IBorrowingService
    {
        public Task Borrow(string bookISBN);
        public Task Return(string bookISBN);
    }
}
