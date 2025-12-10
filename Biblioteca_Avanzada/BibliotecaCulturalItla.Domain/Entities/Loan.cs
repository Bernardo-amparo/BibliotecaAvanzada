using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCulturalItla.Domain.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int BookId { get; set; }
        public int FriendId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool Returned { get; set; }
    }
}
