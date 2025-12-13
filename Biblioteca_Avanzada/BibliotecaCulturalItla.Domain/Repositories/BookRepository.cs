using System.Data;
using System.Threading.Tasks; 
using Dapper;
using Microsoft.Data.SqlClient;
using BibliotecaCulturalItla.Domain.Entities;
using BibliotecaCulturalItla.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BibliotecaCulturalItla.Domain.Repositories
{
    public class BookRepository
    {
        private readonly DBConnection _dbConnection;

        public BookRepository(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = "SELECT BookId, Title, AuthorId, Genre, YearPublished, Available FROM Books";
            return await conn.QueryAsync<Book>(sql);
        }


        public async Task<Book?> GetByIdAsync(int id)
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = @"SELECT BookId, Title, AuthorId, Genre, YearPublished, Available
                           FROM Books WHERE BookId = @Id";
            return await conn.QueryFirstOrDefaultAsync<Book>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(Book book)
        {
            using var conn = _dbConnection.CreateConnection();
           
            string sql = @"INSERT INTO Books (Title, AuthorId, Genre, YearPublished, Available)
                           OUTPUT INSERTED.BookId
                           VALUES (@Title, @AuthorId, @Genre, @YearPublished, @Available)";
            var newId = await conn.ExecuteScalarAsync<int>(sql, book);
            return newId;
        }

        public async Task UpdateAsync(Book book)
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = @"UPDATE Books
                           SET Title = @Title,
                               AuthorId = @AuthorId,
                               Genre = @Genre,
                               YearPublished = @YearPublished,
                               Available = @Available
                           WHERE BookId = @BookId";
            await conn.ExecuteAsync(sql, book);
        }

        public async Task DeleteAsync(int id)
        {
            using var conn = _dbConnection.CreateConnection();
            string sql = "DELETE FROM Books WHERE BookId = @Id";
            await conn.ExecuteAsync(sql, new { Id = id });
        }
    }
}