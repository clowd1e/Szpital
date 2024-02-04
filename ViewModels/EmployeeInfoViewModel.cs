using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.DbContexts;
using Szpital.Models;

namespace Szpital.ViewModels
{
    public class EmployeeInfoViewModel : ViewModelBase
    {
        private readonly Employee employee;
        public int EmployeeId => employee.EmployeeId;
        public string FirstName => employee.FirstName;
        public string LastName => employee.LastName;
        public string HospitalDepartment => DbContext.GetHospitalDepartment(employee);
        public string Specialty => employee.Position == "Doktor" ? employee.Specialty : employee.Position;
        public string Pesel => employee.Pesel;
        public string BirthDate => employee.BirthDate.ToShortDateString();
        public string Address => employee.Address;
        public string City => employee.City;
        public string PhoneNumber => employee.PhoneNumber;
        public string EmploymentDate => employee.EmploymentDate.ToShortDateString();
        public string Salary => string.Format("{0:0,0.00}", Convert.ToDouble(decimal.Round(employee.Salary, 2).ToString()));
        public string Email => employee.Email;
    }
}
