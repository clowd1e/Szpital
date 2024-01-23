using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Szpital.ViewModels;

namespace Szpital.Commands
{
    public class CancelCommand : CommandBase
    {
        private MainViewModel mainViewModel;
        private Window window;
        public override void Execute(object? parameter)
        {
            window.Close();
            mainViewModel.IsDarkLayerShown = false;
        }

        public CancelCommand(MainViewModel mainViewModel, Window window)
        {
            this.mainViewModel = mainViewModel;
            this.window = window;
        }
    }
}
