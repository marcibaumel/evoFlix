using evoFlix.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.State.Navigators
{
    public enum ViewType
    {
        MainLogin,
        MainRegister,
        Accounts,
        Home,
        MyList,
        MyAccount
    }
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }

        event Action StateChanged;
    }
}
