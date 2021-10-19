using evoFlix.DataAccess;
using evoFlix.Models;
using evoFlix.Models.Content;
using evoFlix.Models.Users;
using evoFlix.Services;
using evoFlix.Services.AuthenticationServices;
using evoFlix.Services.DataServices;
using evoFlix.Services.FilmService;
using evoFlix.WPF.State;
using evoFlix.WPF.State.Authenticator;
using evoFlix.WPF.State.Navigators;
using evoFlix.WPF.ViewModels;
using evoFlix.WPF.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace evoFlix.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Login rész
            
            IServiceProvider serviceProvider = CreateServiceProvider();

            Window window = serviceProvider.GetRequiredService<MainWindow>();
            
            
            //videoplayer rész
            //Window window = new MainWindow();

            window.Show();
        }

        //Dependency Injection
        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<UnitOfWork>();
            services.AddSingleton<IDataService<MainUserTableModel>, MainUserService>();
            services.AddSingleton<IDataService<BaseTableModel>, GenericDataService<BaseTableModel>>();
            services.AddSingleton<IDataService<MainUserTableModel>, GenericDataService<MainUserTableModel>>();
           
            services.AddSingleton<IMainUserService, MainUserService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<IRootViewModelFactory, RootViewModelFactory>();


            services.AddSingleton<CreateViewModel<HomeViewModel>>(s =>
            {
                return () => new HomeViewModel();
            });

            services.AddSingleton<CreateViewModel<MyListViewModel>>(s =>
            {
                return () => new MyListViewModel();
            });

            services.AddSingleton<CreateViewModel<MyAccountViewModel>>(s =>
            {
                return () => new MyAccountViewModel(
                    s.GetRequiredService<IAuthenticator>(),
                    new ViewModelFactoryRenavigator<MainLoginViewModel>(
                        s.GetRequiredService<INavigator>(),
                        s.GetRequiredService<CreateViewModel<MainLoginViewModel>>()));
            });

            services.AddSingleton<CreateViewModel<MainLoginViewModel>>(s =>
            {
                return () => new MainLoginViewModel(
                    s.GetRequiredService<IAuthenticator>(),
                    new ViewModelFactoryRenavigator<HomeViewModel>(
                        s.GetRequiredService<INavigator>(),
                        s.GetRequiredService<CreateViewModel<HomeViewModel>>()),
                    new ViewModelFactoryRenavigator<MainRegisterViewModel>(
                        s.GetRequiredService<INavigator>(),
                        s.GetRequiredService<CreateViewModel<MainRegisterViewModel>>()));
            });

            services.AddSingleton<CreateViewModel<MainRegisterViewModel>>(s =>
            {
                return () => new MainRegisterViewModel(
                    s.GetRequiredService<IAuthenticator>(),
                    new ViewModelFactoryRenavigator<MainLoginViewModel>(
                        s.GetRequiredService<INavigator>(),
                        s.GetRequiredService<CreateViewModel<MainLoginViewModel>>()),
                    new ViewModelFactoryRenavigator<MainLoginViewModel>(
                       s.GetRequiredService<INavigator>(),
                        s.GetRequiredService<CreateViewModel<MainLoginViewModel>>()));
            });

            //Out of service
            services.AddSingleton<CreateViewModel<AccountsViewModel>>(s =>
            {
                return () => new AccountsViewModel(
                    s.GetRequiredService<IAuthenticator>(),
                    new ViewModelFactoryRenavigator<HomeViewModel>(
                        s.GetRequiredService<INavigator>(),
                        s.GetRequiredService<CreateViewModel<HomeViewModel>>()));
            });



            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<IAuthenticator, Authenticator>();
            services.AddScoped<MainWindowViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

            return services.BuildServiceProvider();
        }
    }
}
