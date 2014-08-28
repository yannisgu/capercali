using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Capercali.WPF.Converters
{
    public class IgnoreNewItemPlaceholderConverter : IValueConverter
    {
        private const string newItemPlaceholderName = "{NewItemPlaceholder}";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (value == null)
            //    value = DependencyProperty.UnsetValue;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == newItemPlaceholderName)
            {
                if (targetType.IsValueType)
                {
                    value = Activator.CreateInstance(targetType);
                }
                else
                {
                    value = null;
                }
            }
            return value;
        }
    }
}
