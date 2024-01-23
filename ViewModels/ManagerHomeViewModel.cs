using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels
{
    public class ManagerHomeViewModel : ViewModelBase
    {
        private readonly Employee employee;
        private readonly NavigationStore navigationStore;
        private readonly MainViewModel mainViewModel;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        private bool isMale => employee.Pesel[9] % 2 != 0;
        public string WelcomeText => $"Dzień dobry Pani{(isMale ? "e" : "")} Kierowni{(isMale ? "ku" : "czko")}!";

        public ICommand ChangeToDoctors{ get; }
        public ICommand ChangeToUserInfo { get; }

        public ManagerHomeViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, ManagerMenuViewModel managerMenuViewModel, Employee employee, Account account)
        {
            this.employee = employee;
            this.navigationStore = navigationStore;
            this.mainViewModel = mainViewModel;

            ChangeToDoctors = new ManagerHomeNavigateCommand(navigationStore, nameof(ChangeToDoctors), managerMenuViewModel, new ManagerDoctorsViewModel(navigationStore, mainViewModel, employee));
            ChangeToUserInfo = new ManagerHomeNavigateCommand(navigationStore, nameof(ChangeToUserInfo), managerMenuViewModel, new UserInfoViewModel(navigationStore, mainViewModel, employee, account));

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}