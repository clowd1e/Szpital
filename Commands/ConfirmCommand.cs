using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Szpital.ViewModels;

namespace Szpital.Commands
{
    public class ConfirmCommand : CommandBase
    {
        private Window window;
        private ChangePasswordCommand changePasswordCommand;

        public override void Execute(object? parameter)
        {
            window.Close();
            changePasswordCommand.Confirm();
        }
        public ConfirmCommand(Window window, ChangePasswordCommand changePasswordCommand)
        {
            this.window = window;
            this.changePasswordCommand = changePasswordCommand;
        }
    }
}
