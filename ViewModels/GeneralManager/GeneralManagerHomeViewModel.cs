using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels.GeneralManager
{
    public class GeneralManagerHomeViewModel : ViewModelBase
    {
        private readonly Employee employee;
        private readonly NavigationStore navigationStore;
        private readonly MainViewModel mainViewModel;

        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        private bool isMale => employee.Pesel[9] % 2 != 0;
        public string WelcomeText => $"Dzień dobry Pani{(isMale ? "e" : "")} Główn{(isMale ? "y" : "a")} Kierowni{(isMale ? "ku" : "czko")}!";

        public ICommand ChangeToEmployees { get; }
        public ICommand ChangeToUserInfo { get; }

        public GeneralManagerHomeViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, GeneralManagerMenuViewModel generalManagerMenuViewModel, Employee employee, Account account)
        {
            this.employee = employee;
            this.navigationStore = navigationStore;
            this.mainViewModel = mainViewModel;

            ChangeToEmployees = new GeneralManagerHomeNavigateCommand(navigationStore, nameof(ChangeToEmployees), generalManagerMenuViewModel, new GeneralManagerEmployeesViewModel(navigationStore, mainViewModel, employee));
            ChangeToUserInfo = new GeneralManagerHomeNavigateCommand(navigationStore, nameof(ChangeToUserInfo), generalManagerMenuViewModel, new UserInfoViewModel(navigationStore, mainViewModel, employee, account));

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}