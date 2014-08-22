using Capercali.DataAccess.Services;
using Ninject.Modules;

namespace Capercali.DataAccess.RavenDB
{
    public class RavenModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventsService>().To<RavenEventsService>();
        }
    }
}