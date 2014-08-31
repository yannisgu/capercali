
using Capercali.WPF.ViewModel.EventConfiguration;
using Capercali.WPF.ViewModel.EventPage;
using Capercali.WPF.ViewModel.EventRunners;
using Capercali.WPF.ViewModel.EventWindowCommands;
using Capercali.WPF.ViewModel.Main;
using Ninject.Modules;

namespace Capercali.WPF.ViewModel
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<IEventPageViewModel>().To<EventPageViewModel>();
            Bind<IEventWindowCommands>().To<EventWindowCommands.EventWindowCommands>();
            Bind<IEventConfigurationViewModel>().To<EventConfigurationViewModel>();
            Bind<IEventRunnersViewModel>().To<EventRunnersViewModel>();
        }
    }
}