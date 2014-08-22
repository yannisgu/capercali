using System.Windows.Controls;

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

        public Frame Frame
        {
            get { return frame; }
        }
    }
}