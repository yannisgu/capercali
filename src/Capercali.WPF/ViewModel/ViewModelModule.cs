
using Ninject.Modules;

namespace Capercali.WPF.ViewModel
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<IEventPageViewModel>().To<EventPageViewModel>();
            Bind<IEventWindowCommands>().To<EventWindowCommands>();
        }
    }
}