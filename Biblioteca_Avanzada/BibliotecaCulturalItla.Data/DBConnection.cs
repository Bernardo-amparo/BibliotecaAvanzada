using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCulturalItla.Data
{
    public class DBConnection
    {
        private readonly string _connectionString =
            "Server=LAPTOP-6TH38FO\\SQLEXPRESS;Database=BibliotecaCulturalItla;Trusted_Connection=True;";

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
