using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Capercali.WPF.UserControls;
using Capercali.WPF.ViewModel;
using Capercali.WPF.ViewModel.Main;
using ReactiveUI;

namespace Capercali.WPF.Pages
{
    /// <summary>
    ///     Interaction logic for EventSelectionPage.xaml
    /// </summary>
    public partial class EventSelectionPage : IViewFor<IMainViewModel>
    {
        public EventSelectionPage()
        {
            InitializeComponent();

            this.WhenNavigatedTo(ViewModel, () =>
            {
                DataContext = ViewModel;
                return Disposable.Create(() => { });
            });
        }

        public IMainViewModel ViewModel
        {
            get { return (IMainViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(IMainViewModel), typeof(EventSelectionPage),
                new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IMainViewModel)value; }
        }

        private void EventSelectionPage_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (ViewModel.DeleteEvent.CanExecute(sender))
                {
                    ViewModel.DeleteEvent.Execute(sender);
                }
            }
        }
    }
}