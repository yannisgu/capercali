using System.Windows.Controls;
using MahApps.Metro.Controls;

namespace Capercali.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public TransitioningContentControl Frame
        {
            get { return frame; }
        }

        public StackPanel WindowCommandsPanel
        {
            get { return windowCommands; }
        }
    }
}