using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels
{
    public class ManagerDoctorsViewModel : ViewModelBase
    {
        private readonly ObservableCollection<MDListItemViewModel> doctors;

        public ObservableCollection<MDListItemViewModel> Doctors => doctors;

        public ICommand ShowInfo { get; }

        public ManagerDoctorsViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee)
        {
            doctors = DbContext.GetManagerDoctors(employee);
            //ShowInfo = new ShowDoctorsInfoCommand(navigationStore, mainViewModel, this, employee);
            //ShowInfo = new RelayCommand(execute => ShowDoctorInfo);
        }

        private void ShowDoctorInfo(object s)
        {
            throw new NotImplementedException();
        }
    }
}