using System.Data;
using System.Threading.Tasks; // ¡Necesario para Task!
using Dapper;
using Microsoft.Data.SqlClient;
using BibliotecaCulturalItla.Domain.Entities;
using BibliotecaCulturalItla.Data;
using System.Collections.Generic;
using System.Linq;
using System; // Solo si se usa

namespace BibliotecaCulturalItla.Domain.Repositories
{
    public class BookRepository
    {
        private readonly DBConnection _dbConnection;

        public BookRepository(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // 1. GET ALL ASÍNCRONO
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = "SELECT * FROM Book";
            // Usar QueryAsync
            return await conn.QueryAsync<Book>(sql);
        }

        // 2. GET BY ID ASÍNCRONO
        public async Task<Book?> GetByIdAsync(int id)
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = "SELECT * FROM Book WHERE Id = @Id";
            // Usar QueryFirstOrDefaultAsync
            return await conn.QueryFirstOrDefaultAsync<Book>(sql, new { Id = id });
        }

        // 3. INSERT ASÍNCRONO (Renombrado a CreateAsync para consistencia con el servicio)
        public async Task CreateAsync(Book book)
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = @"INSERT INTO Book (Title, AuthorId, Genre, YearPublished)
                             VALUES (@Title, @AuthorId, @Genre, @YearPublished)";
            // Usar ExecuteAsync
            await conn.ExecuteAsync(sql, book);
        }

        // 4. UPDATE ASÍNCRONO
        public async Task UpdateAsync(Book book)
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = @"UPDATE Book 
                             SET Title = @Title,
                                 AuthorId = @AuthorId,
                                 Genre = @Genre,
                                 YearPublished = @YearPublished
                             WHERE Id = @Id";
            // Usar ExecuteAsync
            await conn.ExecuteAsync(sql, book);
        }

        // 5. DELETE ASÍNCRONO
        public async Task DeleteAsync(int id)
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = "DELETE FROM Book WHERE Id = @Id";
            // Usar ExecuteAsync
            await conn.ExecuteAsync(sql, new { Id = id });
        }
    }
}