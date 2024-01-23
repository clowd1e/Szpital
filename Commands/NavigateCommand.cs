using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.Stores;
using Szpital.ViewModels;

namespace Szpital.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore navigateStore;
        private readonly ViewModelBase viewModel;

        public override void Execute(object? parameter)
        {
            navigateStore.CurrentViewModel = viewModel;
        }

        public NavigateCommand(NavigationStore navigationStore, ViewModelBase viewModel)
        {
            this.navigateStore = navigationStore;
            this.viewModel = viewModel;
        }
    }
}
