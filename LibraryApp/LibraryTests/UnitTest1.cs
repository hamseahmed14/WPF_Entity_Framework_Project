using LibraryApp;
using LibraryBusiness;
using NUnit.Framework;
using System.Linq;

namespace LibraryTests
{
    public class RegistrationTests
    {
        MemberCRUDManager _crudmanager = new MemberCRUDManager();
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
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewMemberIsAdded_TheNumberOfMemberssIncreasesBy1()
        {
            var expected = _crudmanager.RetrieveAllMembers().Count();
            _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com", "21A", "London Road", "leicester", "LE8 0SU", "password");
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
            _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com", "21A", "London Road", "leicester", "LE8 0SU", "password");

            AuthenticationManager auth = new AuthenticationManager();
            var result = auth.AuthIsCorrect("Hamse", "password");

            Assert.AreEqual("Hamse", result);

        }

        [Test]
        public void WhenIncorrectAuth_IncorrectMassegeWillBeReturned()
        {
            _crudmanager.CreateMember("Hamse", "Ahmed", "Hamse", "hamse-27@hotmail.com", "21A", "London Road", "leicester", "LE8 0SU", "password");

            AuthenticationManager auth = new AuthenticationManager();
            var result = auth.AuthIsCorrect("hamse", "passsword");

            Assert.AreEqual("Incorrect Credentials", result);

        }

        [Test]
        public void 




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
                db.SaveChanges();
            }
        }
    }
}