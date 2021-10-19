using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels.Factories
{
    public class AccountsViewModelFactory : IViewModelFactory<AccountsViewModel>
    {
        public AccountsViewModel CreateViewModel()
        {
            return new AccountsViewModel();
        }
    }
}
