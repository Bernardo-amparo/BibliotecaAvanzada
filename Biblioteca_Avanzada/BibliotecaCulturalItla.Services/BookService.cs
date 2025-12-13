using System.Collections.Generic;
using System.Threading.Tasks;
using BibliotecaCulturalItla.Domain.Entities;
using BibliotecaCulturalItla.Domain.Repositories;

namespace BibliotecaCulturalItla.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;

        public BookService(BookRepository repo)
        {
            _repo = repo; 
        }

        public Task<IEnumerable<Book>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Book?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<int> CreateAsync(Book book) => _repo.CreateAsync(book); 

        public Task UpdateAsync(Book book) => _repo.UpdateAsync(book);

        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}