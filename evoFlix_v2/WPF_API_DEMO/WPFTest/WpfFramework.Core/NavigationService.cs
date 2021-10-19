using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfFramework.Core
{
    public class NavigationService : ViewModelBase
    {
        public delegate void ActivePageChangedHandler();

        public event ActivePageChangedHandler ActivePageChanged;

        private Frame _frame;
        
        public Page CurrentContent
        {
            get { return (Page)_frame.Content; }
        }

        public RelayCommand GoBackCommand { get; set; }
        public RelayCommand GoForwardCommand { get; set; }

        public NavigationService()
        {
            GoBackCommand = new RelayCommand(GoBack, CanGoBack);
            GoForwardCommand = new RelayCommand(GoForward, CanGoForward);
        }

        public void SetFrame(Frame frame)
        {
            if (frame is null)
            {
                throw new ArgumentNullException(nameof(frame));
            }

            if (_frame is null)
            {
                _frame = frame;
                _frame.Navigated += Navigated;
            }
            else
            {
                throw new InvalidOperationException("NavigationService: The frame has already been set.");
            }
        }

        public void NavigateTo(Page page)
        {
            if (page is null)
            {
                throw new ArgumentNullException(nameof(page));
            }

            _frame.Navigate(page);
        }

        private void Navigated(object sender, NavigationEventArgs e)
        {
            ActivePageChanged?.Invoke();
        }

        public bool IsActiveContent(Page page)
        {
            if (!Equals(CurrentContent, page))
            {
                return false;
            }

            return true;
        }

        public bool CanGoBack()
        {
            if (!_frame.CanGoBack)
            {
                return false;
            }

            return true;
        }

        public bool CanGoForward()
        {
            if (!_frame.CanGoForward)
            {
                return false;
            }

            return true;
        }

        public void GoBack()
        {
            if (!_frame.CanGoBack)
            {
                return;
            }

            _frame.GoBack();
        }

        public void GoForward()
        {
            if (!_frame.CanGoForward)
            {
                return;
            }

            _frame.GoForward();
        }
    }
}
