using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.Stores;
using Szpital.ViewModels;
using Szpital.ViewModels.GeneralManager;

namespace Szpital.Commands
{
    public class GeneralManagerHomeNavigateCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly string commandName;
        private readonly GeneralManagerMenuViewModel generalManagerMenuViewModel;
        private readonly ViewModelBase viewModel;

        public override void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = viewModel;
            switch (commandName)
            {
                case "ChangeToEmployees":
                    generalManagerMenuViewModel.EmployeesChecked = true;
                    break;
                case "ChangeToUserInfo":
                    generalManagerMenuViewModel.UserInfoChecked = true;
                    break;
            }
        }

        public GeneralManagerHomeNavigateCommand(NavigationStore navigationStore, string commandName, GeneralManagerMenuViewModel generalManagerMenuViewModel, ViewModelBase viewModel)
        {
            this.navigationStore = navigationStore;
            this.commandName = commandName;
            this.generalManagerMenuViewModel = generalManagerMenuViewModel;
            this.viewModel = viewModel;
        }
    }
}
