using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.DbContexts;
using Szpital.Exceptions;
using Szpital.Models;
using Szpital.Stores;
using Szpital.ViewModels;
using Szpital.Views;

namespace Szpital.Commands
{
    public class ChangePasswordCommand : CommandBase
    {
        private ChangePasswordViewModel changePasswordViewModel;
        private Account account;
        private MainViewModel mainViewModel;

        public override void Execute(object? parameter)
        {
            changePasswordViewModel.OldPasswordErrorMessage = string.Empty;
            changePasswordViewModel.NewPasswordErrorMessage = string.Empty;
            try
            {
                string? currentPassword = DbContext.GetCurrentPassword(account);
                if (!BCrypt.Net.BCrypt.EnhancedVerify(changePasswordViewModel.OldPassword, currentPassword))
                {
                    throw new InvalidOldPasswordException("Niepoprawne stare hasło.");
                }
                CheckNewPassword(changePasswordViewModel.NewPassword);
                OpenConfirmWindow();
            }
            catch (InvalidOldPasswordException e)
            {
                changePasswordViewModel.OldPasswordErrorMessage = e.Message;
            }
            catch (InvalidNewPasswordException e)
            {
                changePasswordViewModel.NewPasswordErrorMessage = e.Message;
            }
        }

        private void OpenConfirmWindow()
        {
            ConfirmWindowView confirmWindowView = new ConfirmWindowView();
            confirmWindowView.DataContext = new ConfirmWindowViewModel(mainViewModel, confirmWindowView, this);

            mainViewModel.IsDarkLayerShown = true;
            confirmWindowView.ShowDialog();
        }

        private void CheckNewPassword(string? newPassword)
        {
            if (newPassword is null)
            {
                throw new InvalidNewPasswordException("Nowe hasło nie zostało wpisane.");
            }
            if (newPassword.Length < 8 || newPassword.Length > 30)
            {
                throw new InvalidNewPasswordException("Nieporawna długość nowego hasła.");
            }
            if (!new Regex("(.*[A-Z].*)").IsMatch(newPassword))
            {
                throw new InvalidNewPasswordException("Hasło nie zawiera jednej wielkiej litery.");
            }
            if (!new Regex("(.*[a-z].*)").IsMatch(newPassword))
            {
                throw new InvalidNewPasswordException("Hasło nie zawiera min. jednej małej litery.");
            }
            if (!new Regex("(.*\\d.*)").IsMatch(newPassword))
            {
                throw new InvalidNewPasswordException("Hasło nie zawiera min. jednej cyfry.");
            }
        }

        public void Confirm()
        {
            DbContext.ChangePassword(account, changePasswordViewModel.NewPassword);

            SuccessfullyConfirmedWindowView successfullyConfirmedWindowView = new SuccessfullyConfirmedWindowView();
            successfullyConfirmedWindowView.DataContext = new SuccessfullyConfirmedWindowViewModel(mainViewModel, successfullyConfirmedWindowView, "Hasło zostało zmienione");

            successfullyConfirmedWindowView.ShowDialog();
        }

        public ChangePasswordCommand(NavigationStore navigationStore, MainViewModel mainViewModel, ChangePasswordViewModel changePasswordViewModel, Employee employee, Account account)
        {
            this.changePasswordViewModel = changePasswordViewModel;
            this.account = account;
            this.mainViewModel = mainViewModel;
        }
    }
}
