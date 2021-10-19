using evoFlix.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels.Factories
{
    public interface IRootViewModelFactory
    {
        BaseViewModel CreateViewModel(ViewType viewType);
    }
}
