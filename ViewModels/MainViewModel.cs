﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;
using Szpital.ViewModels.Doctor;
using Szpital.ViewModels.GeneralManager;
using Szpital.ViewModels.Manager;
using Szpital.ViewModels.Receptionist;
using Szpital.Views.Receptionist;

namespace Szpital.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Account currentUserAccount;
        private readonly Employee currentUserEmployee;
        public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;
        public ViewModelBase CurrentMenuViewModel => navigationStore.CurrentMenuViewModel;

        private bool isDarkLayerShown = false;
        public bool IsDarkLayerShown
        {
            get { return isDarkLayerShown; }
            set
            {
                isDarkLayerShown = value;
                OnPropertyChanged(nameof(IsDarkLayerShown));
            }
        }

        public MainViewModel(Account account)
        {
            currentUserAccount = account;
            currentUserEmployee = DbContext.GetUserEmployee(currentUserAccount);

            navigationStore = new NavigationStore();

            switch (currentUserEmployee.Position)
            {
                case "Główny kierownik":
                    navigationStore.CurrentMenuViewModel = new GeneralManagerMenuViewModel(navigationStore, this, currentUserAccount, currentUserEmployee);
                    break;
                case "Kierownik":
                    navigationStore.CurrentMenuViewModel = new ManagerMenuViewModel(navigationStore, this, currentUserAccount, currentUserEmployee);
                    break;
                case "Doktor":
                    navigationStore.CurrentMenuViewModel = new DoctorMenuViewModel(navigationStore, this, currentUserAccount, currentUserEmployee);
                    break;
                case "Recepcjonista":
                    navigationStore.CurrentMenuViewModel = new ReceptionistMenuViewModel(navigationStore, this, currentUserAccount, currentUserEmployee);
                    break;
            }

            navigationStore.CurrentMenuViewModelChanged += OnCurrentMenuViewModelChanged;
        }

        private void OnCurrentMenuViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentMenuViewModel));
        }
    }
}
