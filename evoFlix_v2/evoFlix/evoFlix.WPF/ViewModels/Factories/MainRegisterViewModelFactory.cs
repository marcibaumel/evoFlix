using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels.Factories
{
    public class MainRegisterViewModelFactory : IViewModelFactory<MainRegisterViewModel>
    {
        public MainRegisterViewModel CreateViewModel()
        {
            return new MainRegisterViewModel();
        }
    }
}
