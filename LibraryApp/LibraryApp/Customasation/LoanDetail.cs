using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
   public partial class LoanDetail
    {
        public override string ToString()
        {
            return $"{Book.Title} - {Request}";
        }

        public string Details()
        {
            return $"{Book.Title} - {Request}";
        }
    }
}
