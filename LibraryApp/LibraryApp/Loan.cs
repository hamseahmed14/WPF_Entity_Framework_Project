using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public partial class Loan
    {
        public Loan() 
        {
            LoanDetails = new HashSet<LoanDetail>();
        }

        public int LoanId { get; set; }
        public int MemberId { get; set; }
        public DateTime LoanDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual ICollection<LoanDetail> LoanDetails { get; set; }
  
    }
}
