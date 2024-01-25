using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Szpital.Commands;

namespace Szpital.ViewModels.Receptionist
{
    public class ReceptionistAddPatientViewModel : ViewModelBase
    {

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string pesel;
        public string Pesel
        {
            get { return pesel; }
            set
            {
                pesel = value;
                OnPropertyChanged(nameof(Pesel));
            }
        }

        private DateTime birthDate = DateTime.Today;
        public DateTime BirthDate
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
                OnPropertyChanged(nameof(BirthDate));
            }
        }

        private string city;
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }


        private string firstNameErrorMessage;
        public string FirstNameErrorMessage
        {
            get { return firstNameErrorMessage; }
            set
            {
                firstNameErrorMessage = value;
                OnPropertyChanged(nameof(FirstNameErrorMessage));
                OnPropertyChanged(nameof(HasFirstNameErrorMessage));
            }
        }
        public bool HasFirstNameErrorMessage => !string.IsNullOrEmpty(FirstNameErrorMessage);

        private string lastNameErrorMessage;
        public string LastNameErrorMessage
        {
            get { return lastNameErrorMessage; }
            set
            {
                lastNameErrorMessage = value;
                OnPropertyChanged(nameof(LastNameErrorMessage));
                OnPropertyChanged(nameof(HasLastNameErrorMessage));
            }
        }
        public bool HasLastNameErrorMessage => !string.IsNullOrEmpty(LastNameErrorMessage);

        private string peselErrorMessage;
        public string PeselErrorMessage
        {
            get { return peselErrorMessage; }
            set
            {
                peselErrorMessage = value;
                OnPropertyChanged(nameof(PeselErrorMessage));
                OnPropertyChanged(nameof(HasPeselErrorMessage));
            }
        }
        public bool HasPeselErrorMessage => !string.IsNullOrEmpty(PeselErrorMessage);

        private string birthDateErrorMessage;
        public string BirthDateErrorMessage
        {
            get { return birthDateErrorMessage; }
            set
            {
                birthDateErrorMessage = value;
                OnPropertyChanged(nameof(BirthDateErrorMessage));
                OnPropertyChanged(nameof(HasBirthDateErrorMessage));
            }
        }
        public bool HasBirthDateErrorMessage => !string.IsNullOrEmpty(BirthDateErrorMessage);

        private string cityErrorMessage;
        public string CityErrorMessage
        {
            get { return cityErrorMessage; }
            set
            {
                cityErrorMessage = value;
                OnPropertyChanged(nameof(CityErrorMessage));
                OnPropertyChanged(nameof(HasCityErrorMessage));
            }
        }
        public bool HasCityErrorMessage => !string.IsNullOrEmpty(CityErrorMessage);

        private string addressErrorMessage;
        public string AddressErrorMessage
        {
            get { return addressErrorMessage; }
            set
            {
                addressErrorMessage = value;
                OnPropertyChanged(nameof(AddressErrorMessage));
                OnPropertyChanged(nameof(HasAddressErrorMessage));
            }
        }
        public bool HasAddressErrorMessage => !string.IsNullOrEmpty(AddressErrorMessage);

        private string phoneNumberErrorMessage;
        public string PhoneNumberErrorMessage
        {
            get { return phoneNumberErrorMessage; }
            set
            {
                phoneNumberErrorMessage = value;
                OnPropertyChanged(nameof(PhoneNumberErrorMessage));
                OnPropertyChanged(nameof(HasPhoneNumberErrorMessage));
            }
        }
        public bool HasPhoneNumberErrorMessage => !string.IsNullOrEmpty(PhoneNumberErrorMessage);


        public ICommand AddPatient { get; }

        public ReceptionistAddPatientViewModel(MainViewModel mainViewModel)
        {
            AddPatient = new AddPatientCommand(this, mainViewModel);
        }
    }
}
