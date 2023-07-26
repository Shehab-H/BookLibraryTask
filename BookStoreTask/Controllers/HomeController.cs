using BookStoreTask.Interfaces;
using BookStoreTask.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStoreTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookCrud _bookReadService;

        public HomeController(IBookCrud bookReadService)
        {
            _bookReadService = bookReadService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookReadService.GetBooksAsync();
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}