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
    public class ConfirmWindowViewModel : ViewModelBase
    {
        public ICommand Cancel { get; }
        public ICommand Confirm { get; }

        public ConfirmWindowViewModel(MainViewModel mainViewModel, Window window, ChangePasswordCommand changePasswordCommand)
        {
            Cancel = new CancelCommand(mainViewModel, window);
            Confirm = new ConfirmCommand(window, changePasswordCommand);
        }
    }
}
