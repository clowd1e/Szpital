using System.Collections.ObjectModel;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels.Manager
{
    public class ManagerDoctorsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MDListItemViewModel> doctors;

        public ObservableCollection<MDListItemViewModel> Doctors => doctors;

        public ManagerDoctorsViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee)
        {
            doctors = DbContext.GetManagerDoctors(employee);

            foreach (MDListItemViewModel doctor in doctors)
            {
                doctor.ShowInfo = new ShowEmployeeInfoCommand(navigationStore, employee);
            }
        }
    }
}