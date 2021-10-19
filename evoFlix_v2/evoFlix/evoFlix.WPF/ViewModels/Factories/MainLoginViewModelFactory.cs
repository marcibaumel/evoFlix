using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels.Factories
{
    public class MainLoginViewModelFactory : IViewModelFactory<MainLoginViewModel>
    {
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public MainLoginViewModelFactory(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public MainLoginViewModel CreateViewModel()
        {
            return new MainLoginViewModel(_authenticator, _renavigator);
        }
    }
}
