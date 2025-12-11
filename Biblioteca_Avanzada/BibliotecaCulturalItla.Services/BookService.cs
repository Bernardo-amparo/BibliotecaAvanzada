using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaCulturalItla.Domain.Entities;
using BibliotecaCulturalItla.Domain.Repositories;

namespace BibliotecaCulturalItla.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;

        // Constructor de Inyección de Dependencias (DI)
        public BookService(BookRepository repo)
        {
            _repo = repo;
        }

        // Re-transmisión de la tarea asíncrona (Método más eficiente)
        public Task<IEnumerable<Book>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        // Asumimos que el repositorio devuelve el ID (Task<int>)
        public Task CreateAsync(Book book)
        {
            // Opcional: Aquí puedes agregar validaciones de negocio o configuraciones
            // book.Available = true; // Si decides mantener la lógica en el servicio

            return _repo.CreateAsync(book);
        }

        public Task UpdateAsync(Book book)
        {
            return _repo.UpdateAsync(book);
        }

        public Task DeleteAsync(int id)
        {
            return _repo.DeleteAsync(id);
        }
    }
}