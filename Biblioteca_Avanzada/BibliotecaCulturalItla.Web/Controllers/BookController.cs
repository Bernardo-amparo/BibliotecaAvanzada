using BibliotecaCulturalItla.Domain.Entities;
using BibliotecaCulturalItla.Domain;
using BibliotecaCulturalItla.Services;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaCulturalItla.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: /Book
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();
            return View(books);
        }

        // GET: /Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book model)
        {
            if (!ModelState.IsValid) return View(model);

            await _bookService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Book/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // GET: /Book/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book model)
        {
            if (!ModelState.IsValid) return View(model);
            await _bookService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Book/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
