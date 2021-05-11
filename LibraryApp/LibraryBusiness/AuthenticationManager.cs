using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp;

namespace LibraryBusiness
{
    public class AuthenticationManager
    {
        Crypto enc = new Crypto();

        public string AuthIsCorrect(string username, string password)
        {
            
            using (var db = new LibraryContext())
            {
                var selectedMember = db.Members.Where(c => c.Username == username && c.Password == password).ToList();
                if(selectedMember.Count != 0)
                {
                    foreach (var mem in selectedMember)
                    {
                        return mem.Username;
                    }
                    
                }
                return "Incorrect Credentials";
            }
        }


        public char GetRole(string cred)
        {
            using (var db = new LibraryContext())
            {
                var role = db.Members.Where(c => c.Username == cred).ToList();

                foreach (var item in role)
                {
                    return item.Role;
                }

                return ' ';
            }
        }
    }
}
