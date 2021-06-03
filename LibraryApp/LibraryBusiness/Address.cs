using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBusiness
{
    public class Address
    {

        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public Address() { }
       
        public Address(string HNo, string street, string city, string postalCode) 
        {
            HouseNumber = HNo;
            Street = street;
            City = city;
            PostalCode = postalCode;
        }
        
        
    }
}
