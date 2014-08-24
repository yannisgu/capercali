using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capercali.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for EditRow.xaml
    /// </summary>
    public partial class EditRow : UserControl
    {
        public EditRow()
        {
            InitializeComponent();
        }



        public static readonly DependencyProperty labelProperty =
            DependencyProperty.Register("Label", typeof(String),
                typeof(EditRow), new FrameworkPropertyMetadata(string.Empty));

        public String Label
        {
            get { return GetValue(labelProperty).ToString(); }
            set { SetValue(labelProperty, value); }
        }

        public static readonly DependencyProperty valueProperty =
            DependencyProperty.Register("Value", typeof (String),
                typeof (EditRow), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public String Value
        {
            get { return GetValue(valueProperty).ToString(); }
            set { SetValue(valueProperty, value); }
        }
    }
}
