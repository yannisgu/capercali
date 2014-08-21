using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.WPF.Navigation;
using Capercali.WPF.Pages;
using Ninject.Modules;

namespace Capercali.WPF.ViewModel
{
    public class ViewModelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>( );
            Bind<MainViewModel>().ToSelf().InSingletonScope(); 
            Bind<INavigation>().To<Navigation.Navigation>();
            Bind<IEventPageViewModel>().To<EventPageViewModel>();
        }
    }
}
