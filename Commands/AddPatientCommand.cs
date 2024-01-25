using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Szpital.DbContexts;
using Szpital.Exceptions;
using Szpital.ViewModels;
using Szpital.ViewModels.Receptionist;
using Szpital.Views;

namespace Szpital.Commands
{
    public class AddPatientCommand : CommandBase
    {
        private readonly ReceptionistAddPatientViewModel parentViewModel;
        private readonly MainViewModel mainViewModel;

        private string FirstName => parentViewModel.FirstName;
        private string LastName => parentViewModel.LastName;
        private string Pesel => parentViewModel.Pesel;
        private DateTime BirthDate => parentViewModel.BirthDate;
        private string City => parentViewModel.City;
        private string Address => parentViewModel.Address;
        private string PhoneNumber => parentViewModel.PhoneNumber;

        public override void Execute(object? parameter)
        {
            parentViewModel.FirstNameErrorMessage = string.Empty;
            parentViewModel.LastNameErrorMessage = string.Empty;
            parentViewModel.PeselErrorMessage = string.Empty;
            parentViewModel.BirthDateErrorMessage = string.Empty;
            parentViewModel.CityErrorMessage = string.Empty;
            parentViewModel.AddressErrorMessage = string.Empty;
            parentViewModel.PhoneNumberErrorMessage = string.Empty;

            try
            {
                CheckStrings();
                CheckPesel();
                CheckDate();
                CheckPhoneNumber();

                OpenConfirmWindow();
            }
            catch (PatientStringNullException e)
            {
                switch (e.ParamName)
                {
                    case "FirstName":
                        parentViewModel.FirstNameErrorMessage = e.Message;
                        break;
                    case "LastName":
                        parentViewModel.LastNameErrorMessage = e.Message;
                        break;
                    case "Pesel":
                        parentViewModel.PeselErrorMessage = e.Message;
                        break;
                    case "City":
                        parentViewModel.CityErrorMessage = e.Message;
                        break;
                    case "Address":
                        parentViewModel.AddressErrorMessage = e.Message;
                        break;
                    case "PhoneNumber":
                        parentViewModel.PhoneNumberErrorMessage = e.Message;
                        break;
                }
            }
            catch (PeselException e)
            {
                parentViewModel.PeselErrorMessage = e.Message;
            }
            catch (ArgumentOutOfRangeException e)
            {
                parentViewModel.BirthDateErrorMessage = e.Message;
            }
            catch (InvalidPhoneNumberException e)
            {
                parentViewModel.PhoneNumberErrorMessage = e.Message;
            }
        }

        private void OpenConfirmWindow()
        {
            ConfirmWindowView confirmWindowView = new ConfirmWindowView();
            confirmWindowView.DataContext = new ConfirmWindowViewModel(mainViewModel, confirmWindowView, this);

            mainViewModel.IsDarkLayerShown = true;
            confirmWindowView.ShowDialog();
        }

        public void Confirm()
        {
            DbContext.AddPatient(
                    FirstName,
                    LastName,
                    Pesel,
                    BirthDate,
                    City,
                    Address,
                    PhoneNumber
                    );

            SuccessfullyConfirmedWindowView successfullyConfirmedWindowView = new SuccessfullyConfirmedWindowView();
            successfullyConfirmedWindowView.DataContext = new SuccessfullyConfirmedWindowViewModel(mainViewModel, successfullyConfirmedWindowView, "Pacjent został dodany");

            successfullyConfirmedWindowView.ShowDialog();
        }

        private void CheckPhoneNumber()
        {
            if (!new Regex("^[+]48\\s\\d\\d\\d\\s\\d\\d\\d\\s\\d\\d\\d").IsMatch(PhoneNumber))
            {
                throw new InvalidPhoneNumberException("Numer telefonu nie odpowiada wzoru. (+48 xxx xxx xxx)");
            }
        }

        private void CheckStrings()
        {
            if (FirstName is null)
            {
                throw new PatientStringNullException(nameof(FirstName));
            }
            if (LastName is null)
            {
                throw new PatientStringNullException(nameof(LastName));
            }
            if (Pesel is null)
            {
                throw new PatientStringNullException(nameof(Pesel));
            }
            if (City is null)
            {
                throw new PatientStringNullException(nameof(City));
            }
            if (Address is null)
            {
                throw new PatientStringNullException(nameof(Address));
            }
            if (PhoneNumber is null)
            {
                throw new PatientStringNullException(nameof(PhoneNumber));
            }
        }

        private void CheckDate()
        {
            if (BirthDate > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Data urodzenia nie może być późniejsza od dzisiaj.");
            }
        }

        private void CheckPesel()
        {
            if (Pesel.Length != 11)
            {
                throw new PeselException("Długość pesela ma być 11.");
            }
            if (!Pesel.All(char.IsDigit))
            {
                throw new PeselException("Pesel ma się składać tylko z cyfr.");
            }
            if (DbContext.GetAllPesels().Contains(Pesel))
            {
                throw new PeselException("Pesel już istnieje w bazie danych.");
            }
        }

        public AddPatientCommand(ReceptionistAddPatientViewModel receptionistAddPatientViewModel, MainViewModel mainViewModel)
        {
            parentViewModel = receptionistAddPatientViewModel;
            this.mainViewModel = mainViewModel;
        }
    }
}
