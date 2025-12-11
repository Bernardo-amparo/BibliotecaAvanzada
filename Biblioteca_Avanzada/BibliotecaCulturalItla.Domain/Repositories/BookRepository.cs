using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using BibliotecaCulturalItla.Domain.Entities;
using BibliotecaCulturalItla.Data;

namespace BibliotecaCulturalItla.Domain.Repositories
{
    public class BookRepository
    {
        private readonly DBConnection _db;

        public BookRepository()
        {
            _db = new DBConnection();
        }

        public IEnumerable<Book> GetAll()
        {
            using var conn = _db.CreateConnection();
            string sql = "SELECT * FROM Book";
            return conn.Query<Book>(sql);
        }

        public void Add(Book book)
        {
            using var conn = _db.CreateConnection();
            string sql = @"INSERT INTO Book (Title, AuthorId, Genre, YearPublished)
                           VALUES (@Title, @AuthorId, @Genre, @YearPublished)";
            conn.Execute(sql, book);
        }
    }
}
