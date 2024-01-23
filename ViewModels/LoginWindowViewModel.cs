using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.DbContexts;
using Szpital.Stores;

namespace Szpital.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {

        private string username = "wannagorna"; // TODO: delete singed value after testing
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string password = "K0cqXxOG"; // TODO: delete singed value after testing
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand LoginCommand { get; }

        public LoginWindowViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }
    }
}
