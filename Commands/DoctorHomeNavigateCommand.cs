using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.Stores;
using Szpital.ViewModels;

namespace Szpital.Commands
{
    public class DoctorHomeNavigateCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly string commandName;
        private readonly DoctorMenuViewModel doctorMenuViewModel;
        private readonly ViewModelBase viewModel;

        public override void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = viewModel;
            switch (commandName)
            {
                case "ChangeToVisits":
                    doctorMenuViewModel.VisitsChecked = true;
                    break;
                case "ChangeToUserInfo":
                    doctorMenuViewModel.UserInfoChecked = true;
                    break;
            }
        }

        public DoctorHomeNavigateCommand(NavigationStore navigationStore, string commandName, DoctorMenuViewModel doctorMenuViewModel, ViewModelBase viewModel)
        {
            this.navigationStore = navigationStore;
            this.commandName = commandName;
            this.doctorMenuViewModel = doctorMenuViewModel;
            this.viewModel = viewModel;
        }
    }
}
