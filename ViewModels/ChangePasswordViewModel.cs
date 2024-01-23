using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;
using Szpital.Views;

namespace Szpital.ViewModels
{
    public class ChangePasswordViewModel : ViewModelBase
    {
        private string oldPassword;
        public string OldPassword
        {
            get { return oldPassword; }
            set
            {
                oldPassword = value;
                OnPropertyChanged(nameof(OldPassword));
            }
        }
        private string newPassword;
        public string NewPassword
        {
            get { return newPassword; }
            set
            {
                newPassword = value;
                OnPropertyChanged(nameof(NewPassword));
            }
        }

        private string oldPasswordErrorMessage;
        public string OldPasswordErrorMessage
        {
            get { return oldPasswordErrorMessage; }
            set
            {
                oldPasswordErrorMessage = value;
                OnPropertyChanged(nameof(OldPasswordErrorMessage));
                OnPropertyChanged(nameof(HasOldPasswordErrorMessage));
            }
        }
        public bool HasOldPasswordErrorMessage => !string.IsNullOrEmpty(OldPasswordErrorMessage);


        private string newPasswordErrorMessage;
        public string NewPasswordErrorMessage
        {
            get { return newPasswordErrorMessage; }
            set
            {
                newPasswordErrorMessage = value;
                OnPropertyChanged(nameof(NewPasswordErrorMessage));
                OnPropertyChanged(nameof(HasNewPasswordErrorMessage));
            }
        }
        public bool HasNewPasswordErrorMessage => !string.IsNullOrEmpty(NewPasswordErrorMessage);

        public ICommand ChangePassword { get; }

        public ChangePasswordViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee, Account account)
        {
            ChangePassword = new ChangePasswordCommand(navigationStore, mainViewModel, this, employee, account);
        }
    }
}
