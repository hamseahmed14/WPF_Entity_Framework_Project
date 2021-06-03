using LibraryApp;
using LibraryBusiness;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryTests
{
    public class LibraryUnitTests
    {
        CRUDManager _crudmanager = new CRUDManager();
        [SetUp]
        public void Setup()
        {
            using (var db = new LibraryContext())
            {
                var selectedCustomers =
                from m in db.Members
                where m.FirstName == "Hamse"
                select m;

                db.Members.RemoveRange(selectedCustomers);


                var selectedBook =
                    from b in db.Books
                    where b.Title == "This"
                    select b;

                db.Books.RemoveRange(selectedBook);

                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewMemberIsAdded_TheNumberOfMemberssIncreasesBy1()
        {
            var expected = _crudmanager.RetrieveAllMembers().Count();
            _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com", new Address("21A", "London Road", "leicester", "LE8 0SU"), "password");
            var actual = _crudmanager.RetrieveAllMembers().Count();
            Assert.AreEqual(expected, actual - 1);
        }

        [Test]
        public void WhenACorrectEmailIsInputted_TrueWillBeReturned()
        {
            var expected = _crudmanager.IsValidEmailAddress("George@gmail.com");

            Assert.AreEqual(true, expected);
        }

        [Test]
        public void WhenAIncorrectEmailIsInputted_FalseWillBeReturned()
        {
            var expected = _crudmanager.IsValidEmailAddress("Georgegmail.com");

            Assert.AreEqual(false, expected);
        }

        [Test]
        public void WhenAPasswordIsEncrypted_ItIsNotTheSame()
        {
            var password = "password";
            var encrypted = Crypto.Encrypt(password);

            Assert.AreEqual(true, encrypted != password);
        }

        [Test]
        public void WhenAPasswordIsDecrypted_ItIsTheSame()
        {
            var password = "password";
            var encrypted = Crypto.Encrypt(password);
            var decrypted = Crypto.Decrypt(encrypted);

            Assert.AreEqual(true, decrypted == password);
        }

        [Test]
        public void WhenCorrectAuth_CorrectMemberIsReturned()
        {
            _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com",new Address("21A", "London Road", "leicester", "LE8 0SU") , "password");

            AuthenticationManager auth = new AuthenticationManager();
            var result = auth.AuthIsCorrect("Hamse", "password");

            Assert.AreEqual("Hamse", result);

        }

        [Test]
        public void WhenIncorrectAuth_IncorrectMassegeWillBeReturned()
        {
            _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com", new Address("21A", "London Road", "leicester", "LE8 0SU"), "password");

            AuthenticationManager auth = new AuthenticationManager();
            var result = auth.AuthIsCorrect("hamse", "passsword");

            Assert.AreEqual("Incorrect Credentials", result);

        }

        [Test]
        public void WhenListOfAllBooksIsRetrieved_TheListIsNotNull()
        {

            var bookCount = _crudmanager.RetrieveAllBooks().Count;

            Assert.AreEqual(true, bookCount > 0);
        }

        [Test]
        public void WhenListOfAllMembersIsRetrieved_TheListIsNotNull()
        {

            var memberCount = _crudmanager.RetrieveAllMembers().Count;

            Assert.AreEqual(true, memberCount > 0);
        }

        [Test]
        public void WhenListOfAllLoansIsRetrieved_TheListIsNotNull()
        {

            var loanCount = _crudmanager.RetrieveAllMembers().Count;

            Assert.AreEqual(true, loanCount > 0);
        }

        [Test]
        public void WhenSelectedBookIsSet_SelectedBookIsThatValue()
        {
            Book b = new Book()
            {
                BookId = 1,
                AuthorId = 1,
                Title = "This",
                Genre = "Sci-Fi",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };

            _crudmanager.SetSelectedBook(b);

            Assert.AreEqual(b, _crudmanager.SelectedBook);

        }

        [Test]
        public void WhenSelectedLoanDetailIsSet_SelectedLoanIsThatValue()
        {
            LoanDetail l = new LoanDetail() { LoanDetailId = 3, LoanId = 1, BookId = 2, ReturnDate = DateTime.Now, Request = "Pending" };

            _crudmanager.SetSelectedLoanDetail(l);

            Assert.AreEqual(l, _crudmanager.SelectedLoan);
        }

        public void WhenBookIsTakenOutByMember_AvailableBookDecreases()
        {
            Book b = new Book()
            {
                AuthorId = 1,
                Title = "This",
                Genre = "Sci-Fi",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };

            _crudmanager.CreateBook(b);
            var before = _crudmanager.RetrieveBook("This");
            _crudmanager.DecreaseAvailable(before.BookId);
            var after = _crudmanager.RetrieveBook("This");

            Assert.AreEqual(9, after.Available);
        }

        [Test]
        public void WhenBookIsAdded_TheNumberOfBooksIsIncreasedBy1()
        {
            Book b = new Book()
            {
                AuthorId = 1,
                Title = "This",
                Genre = "Sci-Fi",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };

            var before = _crudmanager.RetrieveAllBooks().Count();

            _crudmanager.CreateBook(b);

            var after = _crudmanager.RetrieveAllBooks().Count();

            Assert.AreEqual(before, after - 1);
        }

        [Test]
        public void WhenLoanRequestIsAdded_LoanIsIncreasedBy1()
        {
            using (var db = new LibraryContext())
            {

                Book b = new Book()
                {
                    AuthorId = 1,
                    Title = "This",
                    Genre = "Sci-Fi",
                    Description = "Lorem Ipsum",
                    Available = 10,
                    Quantity = 3,
                    ImageSrc = "Image"
                };

                _crudmanager.CreateBook(b);
                var book = _crudmanager.RetrieveBook("This");

                _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com", new Address("21A", "London Road", "leicester", "LE8 0SU"), "password");
                var member = db.Members.Where(m => m.Username == "Hamse").FirstOrDefault();
                var date = DateTime.Now;
                var returndate = date.AddDays(14);
                var loan = new Loan() { MemberId = member.MemberId, LoanDate = date };

                var loandetail = new LoanDetail() { BookId = book.BookId, Loan = loan, ReturnDate = returndate, Request = "Pending" };

                var before = db.Loans.ToList().Count();
                db.LoanDetails.Add(loandetail);
                db.SaveChanges();
                var after = db.Loans.ToList().Count();

                Assert.AreEqual(before, after - 1);
            }

        }

        [Test]
        public void WhenAllBooksThatAreLinkedToAMemberIsRetrieved_ThenCorrectBookCountIsGiven()
        {
            using (var db = new LibraryContext())
            {


                Book b = new Book()
                {
                    AuthorId = 1,
                    Title = "This",
                    Genre = "Sci-Fi",
                    Description = "Lorem Ipsum",
                    Available = 10,
                    Quantity = 3,
                    ImageSrc = "Image"
                };

                _crudmanager.CreateBook(b);
                var book = _crudmanager.RetrieveBook("This");

                _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com", new Address("21A", "London Road", "leicester", "LE8 0SU"), "password");
                var member = db.Members.Where(m => m.Username == "Hamse").FirstOrDefault();
                var date = DateTime.Now;
                var returndate = date.AddDays(14);
                var loan = new Loan() { MemberId = member.MemberId, LoanDate = date };

                var loandetail = new LoanDetail() { BookId = book.BookId, Loan = loan, ReturnDate = returndate, Request = "Pending" };
                db.LoanDetails.Add(loandetail);
                db.SaveChanges();

                var result = _crudmanager.GetMemberBooks(member.MemberId).Count();

                Assert.AreEqual(1, result);
            }
        }

        [Test]
        public void WhenMemberSearcherThroughBook_CorrectBooksAreReturned()
        {
            Book book1 = new Book()
            {
                AuthorId = 1,
                Title = "This",
                Genre = "Sci-Fi",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };

            Book book2 = new Book()
            {
                AuthorId = 1,
                Title = "Jungle Book",
                Genre = "Sci-Fi",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };

            List<Book> list = new List<Book>();
            list.Add(book1);
            list.Add(book2);

            var result = _crudmanager.Search(list, "Jungle").Count();

            Assert.AreEqual(1, result);

        }

        [Test]
        public void WhenMemberFiltersByGenre_CorrectBooksAreReturned()
        {

            Book book1 = new Book()
            {
                AuthorId = 1,
                Title = "Star Wars",
                Genre = "Sci-Fi",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };

            Book book2 = new Book()
            {
                AuthorId = 1,
                Title = "Star Trek",
                Genre = "Sci-Fi",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };

            Book book3 = new Book()
            {
                AuthorId = 1,
                Title = "Jungle Book",
                Genre = "Adventure",
                Description = "Lorem Ipsum",
                Available = 10,
                Quantity = 3,
                ImageSrc = "Image"
            };


            List<Book> list = new List<Book>();
            list.Add(book1);
            list.Add(book2);
            list.Add(book3);

            var result = _crudmanager.FilterGenre(list,"Sci-Fi").Count();

            Assert.AreEqual(2,result);
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new LibraryContext())
            {
                var selectedCustomers =
                from m in db.Members
                where m.FirstName == "Hamse"
                select m;

                db.Members.RemoveRange(selectedCustomers);


                var selectedBook =
                   from b in db.Books
                   where b.Title == "This"
                   select b;
                db.Books.RemoveRange(selectedBook);

                var selectedLoan =
                    from l in db.Loans
                    where l.MemberId == 1000
                    select l;
                db.Loans.RemoveRange(selectedLoan);

    
                db.SaveChanges();
            }
        }
    }
}