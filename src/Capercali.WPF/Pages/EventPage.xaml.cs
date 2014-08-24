using System.Windows;
using System.Windows.Controls;
using Capercali.WPF.UserControls;

namespace Capercali.WPF.Pages
{
    /// <summary>
    ///     Interaction logic for EventPage.xaml
    /// </summary>
    public partial class EventPage
    {
        public EventPage()
        {
            InitializeComponent();
            var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.WindowCommandsPanel.Children.Clear();
                mainWindow.WindowCommandsPanel.Children.Add(new EventWindowCommands());
        }
    }
}