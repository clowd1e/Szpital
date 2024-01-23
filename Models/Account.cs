using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szpital.Models
{
    public class Account
    {
        public int EmployeeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Account(int employeeId, string password, string username)
        {
            EmployeeId = employeeId;
            Username = username; 
            Password = password;
        }
    }
}
