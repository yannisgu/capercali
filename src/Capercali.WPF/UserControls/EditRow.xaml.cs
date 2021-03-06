﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capercali.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for EditRow.xaml
    /// </summary>
    [ContentProperty("Items")]
    public partial class EditRow : UserControl
    {

        public static readonly DependencyProperty ItemsSourceProperty =
            ItemsControl.ItemsSourceProperty.AddOwner(typeof(EditRow));
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public ItemCollection Items
        {
            get { return _itemsControl.Items; }
        }


        public static readonly DependencyProperty labelProperty =
            DependencyProperty.Register("Label", typeof(String),
                typeof(EditRow), new FrameworkPropertyMetadata(string.Empty));

        public String Label
        {
            get { return GetValue(labelProperty).ToString(); }
            set { SetValue(labelProperty, value); }
        }


        public EditRow()
        {
            InitializeComponent();
        }
    }
}
