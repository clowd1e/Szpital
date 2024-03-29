﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Szpital.ViewModels.GeneralManager
{
    //GeneralManagerDoctorsListItemViewModel
    public class GMDListItemViewModel : ViewModelBase
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICommand ShowInfo { get; set; }

        // Representation class that is used to display data in ListView
        public GMDListItemViewModel(int employeeId, string firstName, string lastName)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
