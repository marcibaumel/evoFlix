using evoFlix.WPF.Commands;
using evoFlix.WPF.Models;
using evoFlix.WPF.ViewModels;
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
       
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel 
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommands(this);

        //public event PropertyChangedEventHandler PropertyChanged;

        
    }
}
