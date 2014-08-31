using System;
using System.Windows.Controls;
using Capercali.WPF.ViewModel;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

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
            AppBootstrapper.ShowDialog.Subscribe(async _ =>
            {
                var ret = await this.ShowMessageAsync( _.Message,"test", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings()
                {
                    ColorScheme = MetroDialogColorScheme.Accented
                });
                _.Return.OnNext(ret == MessageDialogResult.Affirmative);

            });
            DataContext = AppBootstrapper;
        }

        public StackPanel WindowCommandsPanel
        {
            get { return windowCommands; }
        }
    }
}