using Capercali.WPF.Navigation;
using Ninject.Modules;

namespace Capercali.WPF.ViewModel
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<INavigation>().To<Navigation.Navigation>();
            Bind<IEventPageViewModel>().To<EventPageViewModel>();
        }
    }
}