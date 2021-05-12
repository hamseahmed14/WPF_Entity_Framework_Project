using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public partial class Author
    {

        public Author(){

            Books = new HashSet<Book>();
}

        public int AuthorId { get; set; }
        public string Name { get; set; }
     

        public virtual ICollection<Book> Books { get; set; }
    }
}
