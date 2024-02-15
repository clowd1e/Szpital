using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string firstName, string lastName, string pesel, DateTime birthDate, string city, string address, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;
            BirthDate = birthDate;
            City = city;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
}
