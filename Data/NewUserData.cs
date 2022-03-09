using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium_Csharp_2022
{
    public class NewUserData
    {
        private string username;
        private string password;
        private string taxID;
        private string company;
        private string firstName;
        private string lastName;
        private string address1;
        private string address2;
        private string postcode;
        private string city;
        private string email;
        private string phone;

        public NewUserData(string firstName, string lastName, string address1,
        string postcode, string city, string email, string phone)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address1 = address1;
            this.postcode = postcode;
            this.city = city;
            this.email = email;
            this.phone = phone;

        }

        public string Password { get; set; }
        public string TaxID { get; set; }
        public string Company { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
