using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Capercali.WPF.Navigation
{
    class Navigation : INavigation
    {
        private Frame _mainFrame;

        #region Implementation of INavigationService

        public event NavigatingCancelEventHandler Navigating;
        public void NavigateTo(Uri pageUri)
        {

            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageUri);
            }

        }

        public void GoBack()
        {
            if (EnsureMainFrame()
                && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }

        }

        #endregion

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            var mainWindow = System.Windows.Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
                _mainFrame = mainWindow.Frame;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                _mainFrame.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };

                return true;
            }

            return false;
        }

        public void Open<T>()
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(typeof (T).GetConstructor(new Type[] {}).Invoke(new object[] {}));
            }
        }
    }
}
