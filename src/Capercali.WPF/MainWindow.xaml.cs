using System.Windows.Controls;
using Capercali.WPF.ViewModel;
using MahApps.Metro.Controls;

namespace Capercali.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public AppBootstrapper AppBootstrapper { get; protected set; }
        public MainWindow()
        {
            InitializeComponent();
            AppBootstrapper = new AppBootstrapper();
            DataContext = AppBootstrapper;
        }

        public StackPanel WindowCommandsPanel
        {
            get { return windowCommands; }
        }
    }
}