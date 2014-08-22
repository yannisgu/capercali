using Capercali.DataAccess.Services;
using Ninject.Modules;

namespace Capercali.DataAccess.NDatabase
{
    public class NDatabaseModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventsService>().To<NDatabaseEventsService>();
        }
    }
}