using evoFlix.WPF.Commands;
using evoFlix.WPF.Models;
using evoFlix.WPF.ViewModels;
using evoFlix.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _currentViewModel;

        public event Action StateChanged;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

    }
}
