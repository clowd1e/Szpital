﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels.GeneralManager
{
    public class GeneralManagerMenuViewModel : ViewModelBase
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
        private bool employeesChecked;
        public bool EmployeesChecked
        {
            get { return employeesChecked; }
            set
            {
                employeesChecked = value;
                OnPropertyChanged(nameof(employeesChecked));
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
        public ICommand ChangeToEmployees { get; }
        public ICommand ChangeToUserInfo { get; }
        public ICommand Logout { get; }

        public GeneralManagerMenuViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Account account, Employee employee)
        {
            HomeChecked = true;
            this.navigationStore = navigationStore;
            this.navigationStore.CurrentViewModel = new GeneralManagerHomeViewModel(navigationStore, mainViewModel, this, employee, account);
            this.mainViewModel = mainViewModel;

            ChangeToHome = new NavigateCommand(navigationStore, new GeneralManagerHomeViewModel(navigationStore, mainViewModel, this, employee, account));
            ChangeToUserInfo = new NavigateCommand(navigationStore, new UserInfoViewModel(navigationStore, mainViewModel, employee, account));
            ChangeToEmployees = new NavigateCommand(navigationStore, new GeneralManagerEmployeesViewModel(navigationStore, mainViewModel, employee));
            Logout = new LogoutCommand();

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
