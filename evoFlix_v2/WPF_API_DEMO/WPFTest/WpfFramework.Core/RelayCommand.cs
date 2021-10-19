using System;
using System.Windows;
using System.Windows.Input;

namespace WpfFramework.Core
{
    public class RelayCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void RaiseCanExecuteChanged()
        {
            Application.Current.Dispatcher.Invoke(() => { CommandManager.InvalidateRequerySuggested(); });
        }

        public void Execute(object parameter)
        {
            execute();
        }
    }
}