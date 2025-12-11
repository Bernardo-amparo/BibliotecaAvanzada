using BibliotecaCulturalItla.Domain.Repositories;
using BibliotecaCulturalItla.Domain.Entities;

namespace BibliotecaCulturalItla.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;

        public BookService()
        {
            _repo = new BookRepository();
        }

        public void AddBook(Book book)
        {
            // Validaciones de ejemplo
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new Exception("El título es obligatorio.");

            _repo.Add(book);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _repo.GetAll();
        }
    }
}
