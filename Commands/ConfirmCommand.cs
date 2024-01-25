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
        private AddPatientCommand addPatientCommand;
        private ChangePasswordCommand changePasswordCommand;

        public override void Execute(object? parameter)
        {
            window.Close();
            if (changePasswordCommand is not null)
            {
                changePasswordCommand.Confirm();
            } 
            else if (addPatientCommand is not null)
            {
                addPatientCommand.Confirm();
            }
        }
        public ConfirmCommand(Window window, ChangePasswordCommand changePasswordCommand)
        {
            this.window = window;
            this.changePasswordCommand = changePasswordCommand;
        }

        public ConfirmCommand(Window window, AddPatientCommand addPatientCommand)
        {
            this.window = window;
            this.addPatientCommand = addPatientCommand;
        }
    }
}
