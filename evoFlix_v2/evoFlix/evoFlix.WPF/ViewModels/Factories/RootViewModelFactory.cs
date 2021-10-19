using evoFlix.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evoFlix.WPF.ViewModels.Factories
{
    public class RootViewModelFactory : IRootViewModelFactory
    {
        private readonly CreateViewModel<MainLoginViewModel> _createMainLoginVM;
        private readonly CreateViewModel<MainRegisterViewModel> _createMainRegisterVM;
        private readonly CreateViewModel<AccountsViewModel> _createAccountsVM;
        private readonly CreateViewModel<HomeViewModel> _createHomeVM;
        private readonly CreateViewModel<MyListViewModel> _createMyListVM;
        private readonly CreateViewModel<MyAccountViewModel> _createMyAccountVM;

        public RootViewModelFactory(CreateViewModel<MainLoginViewModel> createMainLoginVM,
            CreateViewModel<MainRegisterViewModel> createMainRegisterVM,
            CreateViewModel<AccountsViewModel> createAccountsVM,
            CreateViewModel<HomeViewModel> createHomeVM,
            CreateViewModel<MyListViewModel> createMyListVM,
            CreateViewModel<MyAccountViewModel> createMyAccountVM)
        {
            _createMainLoginVM = createMainLoginVM;
            _createMainRegisterVM = createMainRegisterVM;
            _createAccountsVM = createAccountsVM;
            _createHomeVM = createHomeVM;
            _createMyListVM = createMyListVM;
            _createMyAccountVM = createMyAccountVM;
        }

        public BaseViewModel CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.MainLogin:
                    return _createMainLoginVM();
                case ViewType.MainRegister:
                    return _createMainRegisterVM();
                case ViewType.Accounts:
                    return _createAccountsVM();
                case ViewType.Home:
                    return _createHomeVM();
                case ViewType.MyList:
                    return _createMyListVM();
                case ViewType.MyAccount:
                    return _createMyAccountVM();
                default:
                    throw new ArgumentException("ViewType is not correct");
            }
        }
    }
}
