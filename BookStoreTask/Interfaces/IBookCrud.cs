using BookStoreTask.ViewModels;

namespace BookStoreTask.Interfaces
{
    public interface IBookCrud
    {
        public Task<BookViewModel> GetBookAsync(string ISBN);
        public Task<ICollection<BookViewModel>> GetBooksAsync(int skip=0, int take=10);

        public Task AddBook(AddBookViewModel book);
    }
}
