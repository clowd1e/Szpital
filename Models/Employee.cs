using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class Employee : Person, IEmployee
    {
        public int EmployeeId { get; set; }
        public int MedicineDepartment { get; set; }
        public string Position { get; set; }
        public string? Specialty { get; set; }
        public string Email { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsDeleted { get; set; }

        public Employee(int employeeId,
            int medicineDepartment,
            string position,
            string? specialty,
            string firstName,
            string lastName,
            string pesel,
            string phoneNumber,
            string email,
            DateTime birthDate,
            string address,
            string city,
            DateTime employmentDate,
            decimal salary,
            bool isDeleted = false) : base(firstName, lastName, pesel, birthDate, city, address, phoneNumber)
        {
            EmployeeId = employeeId;
            MedicineDepartment = medicineDepartment;
            Position = position;
            Specialty = specialty;
            Email = email;
            EmploymentDate = employmentDate;
            Salary = salary;
            IsDeleted = isDeleted;
        }
    }
}
