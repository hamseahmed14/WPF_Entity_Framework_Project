using LibraryApp;
using LibraryBusiness;
using NUnit.Framework;
using System.Linq;

namespace LibraryTests
{
    public class Tests
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
            _crudmanager.CreateMember("Hamse", "Ahmed", "hamse-27@hotmail.com", "21A", "London Road", "leicester", "LE8 0SU");
            var actual = _crudmanager.RetrieveAllMembers().Count();
            Assert.AreEqual(expected, actual - 1);
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
                db.SaveChanges();
            }
        }
    }
}