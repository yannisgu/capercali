using Capercali.DataAccess.Services;
using Ninject.Modules;

namespace Capercali.WPF.DesignTimeServices
{
    public class DesignTimeDataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventsService>().To<DesignTimeEventService>();
        }
    }
}