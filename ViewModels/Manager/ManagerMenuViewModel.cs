using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels.Manager
{
    public class ManagerMenuViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

        private readonly MainViewModel mainViewModel;

        private bool homeChecked;
        public bool HomeChecked
        {
            get { return homeChecked; }
            set
            {
                homeChecked = value;
                OnPropertyChanged(nameof(HomeChecked));
            }
        }
        private bool doctorsChecked;
        public bool DoctorsChecked
        {
            get { return doctorsChecked; }
            set
            {
                doctorsChecked = value;
                OnPropertyChanged(nameof(DoctorsChecked));
            }
        }
        private bool userInfoChecked;
        public bool UserInfoChecked
        {
            get { return userInfoChecked; }
            set
            {
                userInfoChecked = value;
                OnPropertyChanged(nameof(UserInfoChecked));
            }
        }
        public ICommand ChangeToHome { get; }
        public ICommand ChangeToDoctors { get; }
        public ICommand ChangeToUserInfo { get; }
        public ICommand Logout { get; }

        public ManagerMenuViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Account account, Employee employee)
        {
            HomeChecked = true;
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModel = new ManagerHomeViewModel(navigationStore, mainViewModel, this, employee, account);
            this.mainViewModel = mainViewModel;

            ChangeToHome = new NavigateCommand(navigationStore, new ManagerHomeViewModel(navigationStore, mainViewModel, this, employee, account));
            ChangeToUserInfo = new NavigateCommand(navigationStore, new UserInfoViewModel(navigationStore, mainViewModel, employee, account));
            ChangeToDoctors = new NavigateCommand(navigationStore, new ManagerDoctorsViewModel(navigationStore, mainViewModel, employee));
            Logout = new LogoutCommand();

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}