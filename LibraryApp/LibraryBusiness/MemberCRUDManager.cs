using LibraryApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryBusiness
{
    public class MemberCRUDManager
    {
        public Member SelectedMember { get; set; }

        public void CreateMember(string firstname, string lastname, string email, string phonenumber, string housenumber, string street, string city, string postalcode, string password)
        {
            var newMember = new Member() {FirstName = firstname, LastName = lastname, Email = email, PhoneNumber = phonenumber, HouseNumber = housenumber,Street = street, City = city, PostalCode = postalcode, Role ='M', Password = password};
            AddMember(newMember);
        }

        public void CreateMember(string firstname, string lastname, string email, string housenumber, string street, string city, string postalcode, string password)
        {
            
            var newMember = new Member() { FirstName = firstname, LastName = lastname, Email = email, HouseNumber = housenumber, Street = street, City = city, PostalCode = postalcode, Role = 'M', Password = password};
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

        public List<Member> RetrieveAllMembers()
        {
            using (var db = new LibraryContext())
            {
                return db.Members.ToList(); ;
            }
        }

        public bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }
}
