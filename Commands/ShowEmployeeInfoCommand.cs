using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;
using Szpital.ViewModels;

namespace Szpital.Commands
{
    public class ShowEmployeeInfoCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Employee employee;

        public ShowEmployeeInfoCommand(NavigationStore navigationStore, Employee employee)
        {
            this.navigationStore = navigationStore;
            this.employee = employee;
        }

        public override void Execute(object? parameter)
        {
            int employeeId = (int)parameter;
            navigationStore.CurrentViewModel = new EmployeeInfoViewModel(navigationStore, employee, DbContext.GetEmployeeInfo(employeeId));
        }
    }
}
