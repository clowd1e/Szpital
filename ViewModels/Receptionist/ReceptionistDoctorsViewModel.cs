using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.Commands;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;
using Szpital.ViewModels.Manager;

namespace Szpital.ViewModels.Receptionist
{
    public class ReceptionistDoctorsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MDListItemViewModel> doctors;

        public ObservableCollection<MDListItemViewModel> Doctors => doctors;

        public ReceptionistDoctorsViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee)
        {
            doctors = DbContext.GetAllDoctors();

            foreach (MDListItemViewModel doctor in doctors)
            {
                doctor.ShowInfo = new ShowEmployeeInfoCommand(navigationStore, employee);
            }
        }
    }
}
