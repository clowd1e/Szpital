using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.DbContexts;
using Szpital.Models;
using Szpital.Stores;
using Szpital.Views;

namespace Szpital.ViewModels
{
    public class UserInfoViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;
        private readonly MainViewModel mainViewModel;

        private ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;
        private readonly Employee employee;
        public int EmployeeId => employee.EmployeeId;
        public string FirstName => employee.FirstName;
        public string LastName => employee.LastName;
        public string HospitalDepartment => DbContext.GetHospitalDepartment(employee);
        public string Specialty => employee.Position == "Doktor" ? employee.Specialty : employee.Position;
        public string Pesel => employee.Pesel;
        public string BirthDate => employee.BirthDate.ToShortDateString();
        public string Address => employee.Address;
        public string City => employee.City;
        public string PhoneNumber => employee.PhoneNumber;
        public string EmploymentDate => employee.EmploymentDate.ToShortDateString();
        public string Salary => string.Format("{0:0,0.00}", Convert.ToDouble(decimal.Round(employee.Salary, 2).ToString()));
        public string Email => employee.Email;

        public ICommand ChangePassword { get; }
        public UserInfoViewModel(NavigationStore navigationStore, MainViewModel mainViewModel, Employee employee, Account account)
        {
            this.navigationStore = navigationStore;
            this.mainViewModel = mainViewModel;
            this.employee = employee;
            ChangePassword = new NavigateCommand(navigationStore, new ChangePasswordViewModel(navigationStore, mainViewModel, employee, account));

            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            mainViewModel.OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
