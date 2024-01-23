using System.Configuration;
using System.Data;
using System.Windows;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;
using Szpital.ViewModels;
using Szpital.Views;

namespace Szpital
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new LoginView()
            {
                DataContext = new LoginWindowViewModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
