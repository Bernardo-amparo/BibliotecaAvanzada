using BibliotecaCulturalItla.Domain.Entities;
using BibliotecaCulturalItla.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaCulturalItla.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _service;

        public BookController()
        {
            _service = new BookService();
        }

        public IActionResult Index()
        {
            var books = _service.GetBooks();
            return View(books);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Book model)
        {
            _service.AddBook(model);
            return RedirectToAction("Index");
        }
    }
}
