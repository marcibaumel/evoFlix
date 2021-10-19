using evoFlix.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : BaseViewModel;

    public class BaseViewModel : ObservableObject
    {
    }
}
