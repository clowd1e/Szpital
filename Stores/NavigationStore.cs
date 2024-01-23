using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szpital.ViewModels;

namespace Szpital.Stores
{
    public class NavigationStore
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set 
            {
                currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }


        private ViewModelBase currentMenuViewModel;
        public ViewModelBase CurrentMenuViewModel
        {
            get => currentMenuViewModel;
            set
            {
                currentMenuViewModel = value;
                OnCurrentMenuViewModelChanged();
            }
        }

        public event Action CurrentMenuViewModelChanged;

        private void OnCurrentMenuViewModelChanged()
        {
            CurrentMenuViewModelChanged?.Invoke();
        }
    }
}
