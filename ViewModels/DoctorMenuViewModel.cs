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
    public class DoctorMenuViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Account currentUserAccount;
        private readonly Employee currentUserEmployee;
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
        private bool visitsChecked;
        public bool VisitsChecked
        {
            get { return visitsChecked; }
            set
            {
                visitsChecked = value;
                OnPropertyChanged(nameof(VisitsChecked));
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
        public ICommand ChangeToVisits { get; }
        public ICommand ChangeToUserInfo { get; }
        public ICommand Logout { get; }


        public DoctorMenuViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Account account, Employee employee)
        {
            HomeChecked = true;
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModel = new DoctorHomeViewModel(navigationStore, mainViewModel, this, employee, account);
            this.mainViewModel = mainViewModel;

            ChangeToHome = new NavigateCommand(navigationStore, new DoctorHomeViewModel(navigationStore, mainViewModel, this, employee, account));
            //ChangeToUserInfo = new NavigateCommand(navigationStore, new DoctorUserInfoViewModel(employee));
            ChangeToUserInfo = new NavigateCommand(navigationStore, new UserInfoViewModel(navigationStore, mainViewModel, employee, account));
            ChangeToVisits = new NavigateCommand(navigationStore, new DoctorVisitsViewModel());
            Logout = new LogoutCommand();

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            currentUserAccount = account;
            currentUserEmployee = employee;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
