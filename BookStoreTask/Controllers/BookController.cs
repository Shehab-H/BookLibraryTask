using BookStoreTask.Exceptions;
using BookStoreTask.Interfaces;
using BookStoreTask.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookStoreTask.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookCrud _bookReadService;
        private readonly IBorrowingService _borrowingService;
        public BookController(IBookCrud bookRead, IBorrowingService borrowingService)
        {
            _bookReadService = bookRead;
            _borrowingService = borrowingService;

        }
        [HttpGet("Book/{ISBN}")]
        public  async Task<IActionResult> Index(string ISBN)
        {
            try
            {
                var book =  await _bookReadService.GetBookAsync(ISBN);
                return View(book);
            }
            catch(BookNotFoundException)
            {
                return  RedirectToAction("BookNotFound","Book");
            }
        }

        [HttpPost("Book/Borrow/{ISBN}")]
        public async Task<IActionResult> Borrow(string ISBN)
        {
            try
            {
                await _borrowingService.Borrow(ISBN);

                return Ok(); 
            }
            catch (NoAvailableCopiesException ex)
            {
                return BadRequest(new {message= ex.Message});
            }
        }
        [HttpPost("Book/Return/{ISBN}")]
        public async Task<IActionResult> Return(string ISBN)
        {
            try
            {
                await _borrowingService.Return(ISBN);

                return Ok();
            }
            catch (AllCopiesReturnedException ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        [HttpGet("Book/BookNotFound")]
        public IActionResult BookNotFound()
        {
            return View();
        }

        [HttpGet("Book/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Book/Add")]
        public async Task<IActionResult> Add(AddBookViewModel book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _bookReadService.AddBook(book);
                    TempData.Remove("AddedFailure");
                    TempData["AddedSuccess"] = "Book Added Successfaly";
                    return View();
                }
                catch (BookExistsException)
                {
                    TempData.Remove("AddedSuccess");
                    TempData["AddedFailure"] = "Book Already Exists  Try Changing ISBN";
                    return View();
                }
            }
            else
            {
                return View();
            }

        }
    }
}
