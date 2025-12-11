using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCulturalItla.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        public bool Available { get; set; } = true;
    }
}
