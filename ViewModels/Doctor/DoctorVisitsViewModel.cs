using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels.Doctor
{
    public class DoctorVisitsViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        private readonly MainViewModel mainViewModel;
        private readonly Employee employee;
        private readonly Account account;
        public ObservableCollection<VisitViewModel> Visits => DbContext.GetVisits(employee.EmployeeId);
        public DoctorVisitsViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee, Account account)
        {
            this.navigationStore = navigationStore;
            this.mainViewModel = mainViewModel;
            this.employee = employee;
            this.account = account;
        }
    }
}
