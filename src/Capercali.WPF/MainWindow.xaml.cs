using System;
using System.Threading;
using System.Windows;
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
            SetLanguageDictionary();
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

        private void SetLanguageDictionary()
        {
            ResourceDictionary dict = new ResourceDictionary();
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "en-US":
                    dict.Source = new Uri("Resources\\StringResources.xaml",
                                  UriKind.Relative);
                    break;
                case "de-CH":
                case "de-DE":
                case "de-AT":
                    dict.Source = new Uri("Resources\\StringResources.de.xaml",
                                       UriKind.Relative);
                    break;
                default:
                    dict.Source = new Uri("Resources\\StringResources.xaml",
                                      UriKind.Relative);
                    break;
            }
            this.Resources.MergedDictionaries.Add(dict);
        } 

        public StackPanel WindowCommandsPanel
        {
            get { return windowCommands; }
        }
    }
}