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
using Capercali.WPF.ViewModel.EventRunners;

namespace Capercali.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for EventRunnersEditForm.xaml
    /// </summary>
    public partial class EventRunnersEditForm : UserControl
    {
        public EventRunnersEditForm()
        {
            InitializeComponent();
        }

        private void UIElement_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            
            {
                ExecuteCommand(e.OriginalSource as FrameworkElement, cancelButton.Command, sender);
            }
           // else if(e.Key == Key.S && Keyboard.Modifiers )
        }

        private void ExecuteCommand(FrameworkElement frameworkElement, ICommand command, object commandArgument )
        {
            var textBox = frameworkElement;
            if (textBox != null)
            {
                FrameworkElement parent = (FrameworkElement) textBox.Parent;
                while (parent != null && !((IInputElement) parent).Focusable)
                {
                    parent = (FrameworkElement) parent.Parent;
                }

                DependencyObject scope = FocusManager.GetFocusScope(textBox);
                FocusManager.SetFocusedElement(scope, parent);
            }

            command.Execute(commandArgument);

            if (textBox != null)
            {
                textBox.Focus();
            }
        }
    }
}
