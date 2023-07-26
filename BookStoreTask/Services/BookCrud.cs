using BookStoreTask.Data;
using BookStoreTask.Data.Models;
using BookStoreTask.Exceptions;
using BookStoreTask.Interfaces;
using BookStoreTask.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStoreTask.Services
{
    public class BookCrud : IBookCrud
    {
        //encapsulating data base access inside an interface or repository
        //was ommited for the sake of simplicity

        // encapsulating  mapping to view model was ommited for the sake of simplicity 

        private readonly ApplicationDbContext _dbContext;

        public BookCrud(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBook(AddBookViewModel book)
        {
            var _book = await _dbContext.Books.SingleOrDefaultAsync(b => b.ISBN == book.ISBN);

            if (_book != null)
            {
                throw new BookExistsException();
            }

            Book bookToAdd = new(book.ISBN, book.Title, new BookCopies(book.NumberOFCopies), string.Empty);

            await _dbContext.AddAsync(bookToAdd);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<BookViewModel> GetBookAsync(string ISBN)
        {
  
            var book = await _dbContext.Books
                .Include(b => b.BookCopies)
                .AsNoTracking()
                .SingleOrDefaultAsync(b => b.ISBN == ISBN);

            if(book == null)
            {
                throw new BookNotFoundException(ISBN);
            }

            return new BookViewModel(book.ISBN, book.Title, book.BookCopies.NoOfAvailableCopies, book.ImageName);            
        }

        public async Task<ICollection<BookViewModel>> GetBooksAsync(int skip=0, int take =10)
        {
            return await _dbContext.Books
                     .AsNoTracking()
                     .Take(take).Skip(skip)
                     .Select(b => new BookViewModel(b.ISBN, b.Title, b.BookCopies.NoOfCopies, b.ImageName))
                     .ToListAsync();
        }
    }
}
