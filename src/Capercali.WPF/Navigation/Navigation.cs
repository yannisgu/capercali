using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Capercali.WPF.Navigation
{
    internal class Navigation : INavigation
    {
        private Frame _mainFrame;


        public event NavigatingCancelEventHandler Navigating;


        public void GoBack()
        {
            if (EnsureMainFrame()
                && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        public void Open<T>()
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(typeof (T).GetConstructor(new Type[] {}).Invoke(new object[] {}));
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            var mainWindow = Application.Current.MainWindow as MainWindow;
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
    }
}