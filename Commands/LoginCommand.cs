using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Szpital.DbContexts;
using Szpital.Exceptions;
using Szpital.Models;
using Szpital.Stores;
using Szpital.ViewModels;
using Szpital.Views;

namespace Szpital.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginWindowViewModel loginWindowViewModel;
        private Account? account;

        public override void Execute(object? parameter)
        {
            loginWindowViewModel.ErrorMessage = string.Empty;
            try
            {
                account = DbContext.IdentifyUser(loginWindowViewModel.Username, loginWindowViewModel.Password);
                ChangeWindow();
            }
            catch (UserIdentifyException e)
            {
                loginWindowViewModel.ErrorMessage = e.Message;
            }
            catch (Exception e)
            {
                loginWindowViewModel.ErrorMessage = e.Message;
            }
        }

        private void ChangeWindow()
        {
            MainWindow mainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(account)
            };
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        public LoginCommand(LoginWindowViewModel loginWindowViewModel)
        {
            this.loginWindowViewModel = loginWindowViewModel;
        }
    }
}
