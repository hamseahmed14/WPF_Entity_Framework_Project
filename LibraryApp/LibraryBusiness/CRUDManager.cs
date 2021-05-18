using LibraryApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryBusiness
{
    public class CRUDManager
    {
        public Book SelectedBook { get; set; }
        public LoanDetail SelectedLoan { get; set; }

        public void CreateMember(string firstname, string lastname,string username , string email, string phonenumber, string housenumber, string street, string city, string postalcode, string password)
        {
            var newMember = new Member() {FirstName = firstname, LastName = lastname,Username = username, Email = email, PhoneNumber = phonenumber, HouseNumber = housenumber,Street = street, City = city, PostalCode = postalcode, Role ='M', Password = password};
            AddMember(newMember);
        }

        public void CreateMember(string firstname, string lastname,string username ,string email, string housenumber, string street, string city, string postalcode, string password)
        {
            
            var newMember = new Member() { FirstName = firstname, LastName = lastname,Username = username ,Email = email, HouseNumber = housenumber, Street = street, City = city, PostalCode = postalcode, Role = 'M', Password = password};
            AddMember(newMember);
        }

        private void AddMember(Member member)
        {
            using (var db = new LibraryContext())
            {
                db.Members.Add(member);
                db.SaveChanges();
            }
        }

        public void CreateBook(Book book)
        {
            using (var db = new LibraryContext())
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public Book RetrieveBook(string Title)
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Where(b => b.Title == Title).FirstOrDefault();
            }
        }

        public List<Member> RetrieveAllMembers()
        {
            using (var db = new LibraryContext())
            {
                return db.Members.ToList(); ;
            }
        }

        public List<Book> RetrieveAllBooks()
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Include(b => b.Author).ToList(); 
            }

        }

        public void SetSelectedBook(object selectedItem)
        {
            SelectedBook = (Book)selectedItem;
        }


        public void SetSelectedLoanDetail(object selectedItem)
        {
            SelectedLoan = (LoanDetail)selectedItem;
        }


        public bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public void InputAuthorCSV(List<string> authors)
        {
            using (var db = new LibraryContext())
            {
                foreach (var item in authors)
                {
                    var newAuthor = new Author() { Name = item };
                    db.Authors.Add(newAuthor);
                    db.SaveChanges();
                }
            }
        }

        public List<Book> Search(List<Book> searchList, string searchWord)
        {
            var list = new List<Book>();
            foreach (var item in searchList)
            {
                if (item.Title.ToLower().Contains(searchWord.ToLower()))
                {
                    list.Add(item);
                }
            }

            return list;
        }

        public List<Book> FilterGenre(List<Book> filterList,string genre)
        {
            var list = new List<Book>();
            foreach (var item in filterList)
            {
                if (item.Genre == genre)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        public List<Book> AddGenre(string genre) 
        {
            using (var db = new LibraryContext())
            {
                return db.Books.Where(b => b.Genre == genre).ToList();
            }
        
        }

        public Book GetBookDetails(int id)
        {
            using (var db = new LibraryContext())
            {

                return db.Books.Include(b => b.Author).Where(b => b.BookId == id).FirstOrDefault();
                
            }
        
        }

        public Book TransferObject(Object book)
        {
            return (Book)book;
        }

        public void CreateLoanRequest(int memberId, int bookId)
        {
            using (var db = new LibraryContext())
            {
                var date = DateTime.Now;
                var returndate = date.AddDays(14);
                var loan = new Loan() { MemberId = memberId, LoanDate = date };

                var loandetail = new LoanDetail() { BookId = bookId, Loan = loan, ReturnDate = returndate, Request = "Pending" };

                db.LoanDetails.Add(loandetail);
                db.SaveChanges();
            }

        }

       public int GetMemberId(string username)
        {
            using (var db = new LibraryContext())
            {
                return db.Members.Where(m => m.Username == username).Select(m => m.MemberId).FirstOrDefault();
            }
        }

        public void RemoveLoan(int memberId,int bookId)
        {
            using (var db = new LibraryContext())
            {
                var loanid = db.LoanDetails.Where(l => l.BookId == bookId).Select(l => l.LoanId).FirstOrDefault();
                var selectedLoan = db.Loans.Where(l => l.LoanId == loanid && l.MemberId == memberId).FirstOrDefault();
                db.Loans.Remove(selectedLoan);
                db.SaveChanges();
            }
        }

        public void DenyLoan(int loanDetailId)
        {
            using (var db = new LibraryContext())
            {
                SelectedLoan = db.LoanDetails.Find(loanDetailId);
                SelectedLoan.Request = "Denied";
                db.SaveChanges();
            }
        }

        public void ApproveLoan(int LoanDetailId)
        {
            using (var db = new LibraryContext())
            {
                SelectedLoan = db.LoanDetails.Find(LoanDetailId);
                SelectedLoan.Request = "Approved";
                db.SaveChanges();
            }
        }

        public void DecreaseAvailable(int bookId)
        {
            using (var db = new LibraryContext())
            {
                SelectedBook = db.Books.Find(bookId);
                SelectedBook.Available = SelectedBook.Available -1;
                db.SaveChanges();
            }
        }

        public string RequestedState(int memberId, int bookId)
        {
            using (var db = new LibraryContext())
            {
                return db.LoanDetails.Include(l => l.Loan).Where(l => l.BookId == bookId && l.Loan.MemberId == memberId).Select(l => l.Request).FirstOrDefault();
            }
        }

        public List<LoanDetail> GetAllLoans()
        {
            using (var db  = new LibraryContext())
            {

                return db.LoanDetails.Include(l => l.Loan).ThenInclude(l => l.Member).Where(l => l.Request == "Pending").Include(l => l.Book).ToList();
            }
        }

        public List<LoanDetail> GetMemberBooks(int memberId)
        {
            using (var db = new LibraryContext())
            {
                return db.LoanDetails.Include(b => b.Book).Include(l => l.Loan).ThenInclude(m => m.Member).Where(m => m.Loan.Member.MemberId == memberId).ToList();
            }
        }
 
    }
}
