using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Szpital.Stores;
using Szpital.ViewModels;
using Szpital.Views;

namespace Szpital.Commands
{
    public class LogoutCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            LoginView loginView = new LoginView()
            {
                DataContext = new LoginWindowViewModel()
            };
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = loginView;
            loginView.Show();
        }
    }
}
