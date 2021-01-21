using evoFlix.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace evoFlix.WPF.ViewModels
{
    public class HomeViewModel: ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public Window mainWindow { get; set; } = Application.Current.MainWindow;

    }
}
