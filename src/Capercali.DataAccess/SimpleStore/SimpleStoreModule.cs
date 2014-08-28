using Capercali.DataAccess.Services;
using Ninject.Modules;

namespace Capercali.DataAccess.SimpleStore
{
    public class SimpleStoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventsService>().To<SimpleStoreEventsService>().InSingletonScope();
            Bind<IEventConfigurationService>().To<SimpleStoreEventConfigurationService>().InSingletonScope();
            
         }
    }
}