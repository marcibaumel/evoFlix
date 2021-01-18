using evoFlix.WPF.State.Navigators;
using evoFlix.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.Commands
{
    class UpdateCurrentViewModelCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;

        /*
         * Kapot érték alapján generál egy új ViewModel-t
         */

        public UpdateCurrentViewModelCommands(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*
             * Kapott paraméter alapján eldönti melyiket is kell betölteni
             */

            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                
                /*
                 * Kapott view type alapján az aktuális view modellen változtatunk
                 */

                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.Movies:
                        _navigator.CurrentViewModel = new MoviesViewModel();
                        break;
                    case ViewType.TV_Shows:
                        _navigator.CurrentViewModel = new TVSeriesViewModel();
                        break;
                    case ViewType.My_List:
                        _navigator.CurrentViewModel = new MyListViewModel();
                        break;
                    case ViewType.Account:
                        _navigator.CurrentViewModel = new AccountViewModel();
                        break;
                }
            }
        }
    }
}