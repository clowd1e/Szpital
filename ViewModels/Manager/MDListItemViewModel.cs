using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Szpital.Commands;
using Szpital.Models;
using Szpital.Stores;

namespace Szpital.ViewModels.Manager
{
    // ManagerDoctorsListItemViewModel
    public class MDListItemViewModel : ViewModelBase
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICommand ShowInfo { get; set; }

        // Representation class that is used to display data in ListView
        public MDListItemViewModel(int doctorId, string firstName, string lastName)
        {
            DoctorId = doctorId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
