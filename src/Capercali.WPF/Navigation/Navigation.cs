using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;

namespace Capercali.WPF.Navigation
{
    internal class Navigation : INavigation
    {
        private TransitioningContentControl _mainFrame;



        public void Open<T>()
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Content = typeof (T).GetConstructor(new Type[] {}).Invoke(new object[] {});
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
               

                return true;
            }

            return false;
        }
    }
}