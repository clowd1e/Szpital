using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class Patient : Person
    {
        public int PatientId { get; set; }
        public Patient(int patientId, string firstName, string lastName, string pesel, DateTime birthDate, string city, string address, string phoneNumber) : base(firstName, lastName, pesel, birthDate, city, address, phoneNumber)
        {
            PatientId = patientId;
        }

        public string GetFullName() => $"{FirstName} {LastName}";
    }
}
