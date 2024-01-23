using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public interface IEmployee
    {
        public int EmployeeId { get; set; }
        public int MedicineDepartment { get; set; }
        public string Position { get; set; }
        public string? Specialty { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }
    }
}
