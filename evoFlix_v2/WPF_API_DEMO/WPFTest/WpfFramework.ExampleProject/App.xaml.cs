using Autofac;
using System.Reflection;
using System.Windows;
using WpfFramework.Core;

namespace WpfFramework.ExampleProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();

            var wpfApp = Assembly.GetExecutingAssembly();
            var wpfFramework = typeof(NavigationService).Assembly;

            builder.RegisterAssemblyTypes(wpfApp);
            builder.RegisterAssemblyTypes(wpfFramework);

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var mainWindow = scope.Resolve<MainWindow>();
                mainWindow.Show();
            }
        }
    }
}
