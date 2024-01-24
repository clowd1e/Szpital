using System.Collections.ObjectModel;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels
{
    public class GeneralManagerEmployeesViewModel : ViewModelBase
    {
        private readonly ObservableCollection<GMDListItemViewModel> employees;

        public ObservableCollection<GMDListItemViewModel> Employees => employees;

        public GeneralManagerEmployeesViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee)
        {
            employees = DbContext.GetAllGMEmployees();
        }
    }
}