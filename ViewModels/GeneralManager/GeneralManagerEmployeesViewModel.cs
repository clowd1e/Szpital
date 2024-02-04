using System.Collections.ObjectModel;
using Szpital.Commands;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;
using Szpital.ViewModels.Manager;

namespace Szpital.ViewModels.GeneralManager
{
    public class GeneralManagerEmployeesViewModel : ViewModelBase
    {
        private readonly ObservableCollection<GMDListItemViewModel> employees;

        public ObservableCollection<GMDListItemViewModel> Employees => employees;

        public GeneralManagerEmployeesViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee)
        {
            employees = DbContext.GetAllGMEmployees();

            foreach (GMDListItemViewModel _employee in employees)
            {
                _employee.ShowInfo = new ShowEmployeeInfoCommand(navigationStore, employee);
            }
        }
    }
}