
using Capercali.WPF.ViewModel.EventConfiguration;
using Capercali.WPF.ViewModel.EventPage;
using Capercali.WPF.ViewModel.EventRunners;
using Capercali.WPF.ViewModel.EventWindowCommands;
using Capercali.WPF.ViewModel.Main;
using Ninject;
using Ninject.Modules;

namespace Capercali.WPF.ViewModel
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<IEventPageViewModel>().To<EventPageViewModel>().InScope(_ => _.Kernel.Get<IMainViewModel>().SelectedEvent);
            Bind<IEventWindowCommands>().To<EventWindowCommands.EventWindowCommands>().InScope(_ => Kernel.Get<IMainViewModel>().SelectedEvent);
            Bind<IEventConfigurationViewModel>().To<EventConfigurationViewModel>().InScope(_ => Kernel.Get<IMainViewModel>().SelectedEvent);
            Bind<IEventRunnersViewModel>().To<EventRunnersViewModel>().InScope(_ => Kernel.Get<IMainViewModel>().SelectedEvent);
        }
    }
}