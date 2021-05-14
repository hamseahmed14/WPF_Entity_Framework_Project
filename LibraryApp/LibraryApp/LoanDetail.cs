using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public partial class LoanDetail
    {
        public int LoanDetailId { get; set; }
        public int BookId { get; set; }
        public int LoanId { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Request { get; set; }

        public virtual Book Book { get; set; }
        public virtual Loan Loan { get; set; }
    }
}
