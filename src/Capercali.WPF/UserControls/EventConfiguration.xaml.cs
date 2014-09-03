using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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
using Capercali.Entities;
using Capercali.WPF.ViewModel;
using Capercali.WPF.ViewModel.EventConfiguration;
using ReactiveUI;

namespace Capercali.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for EventConfiguration.xaml
    /// </summary>
    public partial class EventConfiguration : UserControl
    {
        public EventConfigurationViewModel ViewModel { get; set; }

        public EventConfiguration()
        {
            InitializeComponent();

            AddCourseButton.Command =  AddCourse = new ReactiveCommand();
            AddCourse.Subscribe(_ =>
            {
                var item = new CourseViewModel();
                ViewModel.Courses.Add(item);
                var thisItem = CoursesDataGrid.Items[CoursesDataGrid.Items.Count - 1];
                var cellInfo = new DataGridCellInfo(thisItem, CoursesDataGrid.Columns[0]);

                var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
                if (cellContent != null)
                {
                    var cell = (DataGridCell)cellContent.Parent;

                    if (!cell.IsFocused)
                    {
                        cell.Focus();
                    }
                    var row = FindVisualParent<DataGridRow>(cell);
                    if (row != null && !row.IsSelected)
                    {
                        row.IsSelected = true;
                    }
                }

                CoursesDataGrid.BeginEdit();
            });

            DataContextChanged += EventConfiguration_DataContextChanged;

            
        }

        static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                {
                    return correctlyTyped;
                }

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        } 

        void EventConfiguration_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
            ViewModel = DataContext as EventConfigurationViewModel;
            if (ViewModel != null)
            {
                var cannAddControl = ViewModel.WhenAny(y => y.SelectedCourse, y => y.Value != null);
                AddControlButton.Command = AddControl = new ReactiveCommand(cannAddControl);
            }
        }

        public ReactiveCommand AddControl { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public ReactiveCommand AddCourse { get; set; }
    }
}
