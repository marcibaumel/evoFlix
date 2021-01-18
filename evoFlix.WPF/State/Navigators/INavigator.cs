using evoFlix.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace evoFlix.WPF.State.Navigators
{
    /*
     * Ezek közül tudunk választani amit majd "betült"
     */

    public enum ViewType
    {
        Home,
        Movies,
        TV_Shows,
        My_List,
        Account
    }

    /*
     * Implementálandó, hogy elérhessük a ViewModel-t 
     */

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
