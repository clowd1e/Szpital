using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.Stores;
using Szpital.ViewModels;
using Szpital.ViewModels.Manager;

namespace Szpital.Commands
{
    public class ManagerHomeNavigateCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly string commandName;
        private readonly ManagerMenuViewModel managerMenuViewModel;
        private readonly ViewModelBase viewModel;

        public override void Execute(object? parameter)
        {
            navigationStore.CurrentViewModel = viewModel;
            switch (commandName)
            {
                case "ChangeToDoctors":
                    managerMenuViewModel.DoctorsChecked = true;
                    break;
                case "ChangeToUserInfo":
                    managerMenuViewModel.UserInfoChecked = true;
                    break;
            }
        }

        public ManagerHomeNavigateCommand(NavigationStore navigationStore, string commandName, ManagerMenuViewModel managerMenuViewModel, ViewModelBase viewModel)
        {
            this.navigationStore = navigationStore;
            this.commandName = commandName;
            this.managerMenuViewModel = managerMenuViewModel;
            this.viewModel = viewModel;
        }
    }
}
