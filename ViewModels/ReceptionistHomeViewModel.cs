using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels
{
    public class ReceptionistHomeViewModel : ViewModelBase
    {
        private readonly Employee employee;
        private readonly NavigationStore navigationStore;
        private readonly MainViewModel mainViewModel;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        private bool isMale => employee.Pesel[9] % 2 != 0;
        public string WelcomeText => $"Dzień dobry Pani{(isMale ? "e" : "")} Recepcjonisto!";

        public ICommand ChangeToVisits { get; }
        public ICommand ChangeToDoctors { get; }
        public ICommand ChangeToAddPatient { get; }
        public ICommand ChangeToUserInfo { get; }

        public ReceptionistHomeViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, ReceptionistMenuViewModel receptionistMenuViewModel, Employee employee, Account account)
        {
            this.employee = employee;
            this.navigationStore = navigationStore;
            this.mainViewModel = mainViewModel;

            ChangeToVisits = new ReceptionistHomeNavigateCommand(navigationStore, nameof(ChangeToVisits), receptionistMenuViewModel, new ReceptionistVisitsViewModel());
            ChangeToDoctors = new ReceptionistHomeNavigateCommand(navigationStore, nameof(ChangeToDoctors), receptionistMenuViewModel, new ReceptionistDoctorsViewModel());
            ChangeToAddPatient = new ReceptionistHomeNavigateCommand(navigationStore, nameof(ChangeToAddPatient), receptionistMenuViewModel, new ReceptionistAddPatientViewModel());
            ChangeToUserInfo = new ReceptionistHomeNavigateCommand(navigationStore, nameof(ChangeToUserInfo), receptionistMenuViewModel, new UserInfoViewModel(navigationStore, mainViewModel, employee, account));

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
