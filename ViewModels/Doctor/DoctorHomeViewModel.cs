using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels.Doctor
{
    public class DoctorHomeViewModel : ViewModelBase
    {
        private readonly Employee employee;
        private readonly NavigationStore navigationStore;
        private readonly MainViewModel mainViewModel;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        private bool isMale => employee.Pesel[9] % 2 != 0;
        public string WelcomeText => $"Dzień dobry Pani{(isMale ? "e" : "")} Doktor{(isMale ? "ze" : "")}!";

        public ICommand ChangeToVisits { get; }
        public ICommand ChangeToUserInfo { get; }

        public DoctorHomeViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, DoctorMenuViewModel doctorMenuViewModel, Employee employee, Account account)
        {
            this.employee = employee;
            this.navigationStore = navigationStore;
            this.mainViewModel = mainViewModel;

            ChangeToVisits = new DoctorHomeNavigateCommand(navigationStore, nameof(ChangeToVisits), doctorMenuViewModel, new DoctorVisitsViewModel());
            ChangeToUserInfo = new DoctorHomeNavigateCommand(navigationStore, nameof(ChangeToUserInfo), doctorMenuViewModel, new UserInfoViewModel(navigationStore, mainViewModel, employee, account));

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
