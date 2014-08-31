using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using Capercali.WPF.ViewModel;
using Capercali.WPF.ViewModel.EventPage;
using ReactiveUI;
using EventWindowCommands = Capercali.WPF.UserControls.EventWindowCommands;

namespace Capercali.WPF.Pages
{
    /// <summary>
    ///     Interaction logic for EventPage.xaml
    /// </summary>
    public partial class EventPage : IViewFor<IEventPageViewModel>
    {
        EventWindowCommands  commands;

        public EventPage()
        {
            InitializeComponent();
            var mainWindow = Application.Current.MainWindow as MainWindow;
            commands = new EventWindowCommands();
            mainWindow.WindowCommandsPanel.Children.Clear();
            mainWindow.WindowCommandsPanel.Children.Add(commands);

            this.WhenNavigatedTo(ViewModel, () =>
            {
                DataContext = ViewModel;
                commands.DataContext = ViewModel.Commands;
                return Disposable.Create(() => { });
            });
        }

        public IEventPageViewModel ViewModel
        {
            get { return (IEventPageViewModel) GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(IEventPageViewModel), typeof(EventPage),
                new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (IEventPageViewModel)value; }
        }
    }

// XXX: Ignore the man behind this curtain. This will soon be in ReactiveUI itself
    public static class ViewForMixins
    {
        public static IDisposable WhenNavigatedTo<TView, TViewModel>(this TView This, TViewModel viewModel,
            Func<IDisposable> onNavigatedTo)
            where TView : IViewFor<TViewModel>
            where TViewModel : class, IRoutableViewModel
        {
            var disp = Disposable.Empty;
            var inner = This.WhenAny(x => x.ViewModel, x => x.Value)
                .Where(x => x != null && x.HostScreen.Router.GetCurrentViewModel() == x)
                .Subscribe(x =>
                {
                    if (disp != null) disp.Dispose();
                    disp = onNavigatedTo();
                });
            return Disposable.Create(() =>
            {
                inner.Dispose();
                disp.Dispose();
            });
        }
    }
}