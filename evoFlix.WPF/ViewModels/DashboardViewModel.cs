using evoFlix.WPF.Commands;
using evoFlix.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels
{
    public class DashboardViewModel: ViewModelBase
    {
        public INavigator Navigator { get; set; } = new Navigator();

        public Command homeViewCommand;


        public DashboardViewModel()
        {
            homeViewCommand = new Command(ExecuteHomeView, CanExecuteHomeView);
        }



        public bool CanExecuteHomeView(object para)
        {
            return true;
        }

        public void ExecuteHomeView(object para)
        {
            Navigator.CurrentViewModel = new HomeViewModel();
        }
    }
}
