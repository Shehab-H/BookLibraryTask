using BookStoreTask.Data;
using BookStoreTask.Data.Models;
using BookStoreTask.Exceptions;
using BookStoreTask.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreTask.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly ApplicationDbContext _dbContext;
        public BorrowingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Borrow(string bookISBN)
        {
            var bookCopies = await GetBookCopiesAync(bookISBN);
            bookCopies.Borrow();
            await _dbContext.SaveChangesAsync();
        }

        public async Task Return(string bookISBN)
        {
            var bookCopies = await GetBookCopiesAync(bookISBN);
            bookCopies.Return();
            await _dbContext.SaveChangesAsync();
        }

        //this method should be inside a repository and we should use a unit of work 
        //however it was ommited for simplicity and it would be done in a real big project 
        //the seprate method was made to not repeat code 
        private async Task<BookCopies> GetBookCopiesAync(string bookISBN)
        {
             var bookCopies = await _dbContext
            .BookCopies
            .SingleOrDefaultAsync(bc => bc.BookISBN == bookISBN );
            if (bookCopies == null)
            {
                throw new BookNotFoundException(bookISBN);
            }
            return bookCopies;
        }
    }
}
