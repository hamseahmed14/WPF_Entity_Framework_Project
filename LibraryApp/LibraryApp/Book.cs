using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public partial class Book
    {
        public Book()
        {
            LoanDetails = new HashSet<LoanDetail>();
        }

        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Available { get; set; }
        public string ImageSrc { get; set; }

        public virtual ICollection<LoanDetail> LoanDetails { get; set; }
    }
}
