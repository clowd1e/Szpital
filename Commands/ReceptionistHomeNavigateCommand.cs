using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.Stores;
using Szpital.ViewModels;
using Szpital.ViewModels.Receptionist;

namespace Szpital.Commands
{
    public class ReceptionistHomeNavigateCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly string commandName;
        private readonly ReceptionistMenuViewModel receptionistMenuViewModel;
        private readonly ViewModelBase viewModel;

        public override void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = viewModel;
            switch (commandName)
            {
                case "ChangeToAddPatient":
                    receptionistMenuViewModel.AddPatientChecked = true;
                    break;
                case "ChangeToUserInfo":
                    receptionistMenuViewModel.UserInfoChecked = true;
                    break;
                case "ChangeToDoctors":
                    receptionistMenuViewModel.DoctorsChecked = true;
                    break;
                case "ChangeToVisits":
                    receptionistMenuViewModel.VisitsChecked = true;
                    break;
            }
        }

        public ReceptionistHomeNavigateCommand(NavigationStore navigationStore, string commandName, ReceptionistMenuViewModel receptionistMenuViewModel, ViewModelBase viewModel)
        {
            this.navigationStore = navigationStore;
            this.commandName = commandName;
            this.receptionistMenuViewModel = receptionistMenuViewModel;
            this.viewModel = viewModel;
        }
    }
}
