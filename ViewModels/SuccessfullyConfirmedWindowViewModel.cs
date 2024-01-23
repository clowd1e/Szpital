using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Szpital.Commands;

namespace Szpital.ViewModels
{
    public class SuccessfullyConfirmedWindowViewModel : ViewModelBase
    {
        public ICommand Close { get; }

        public SuccessfullyConfirmedWindowViewModel(MainViewModel mainViewModel, Window window, ChangePasswordCommand changePasswordCommand)
        {
            Close = new CancelCommand(mainViewModel, window);
        }
    }
}
