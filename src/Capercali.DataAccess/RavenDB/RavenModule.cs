using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.DataAccess.Services;
using Ninject.Modules;

namespace Capercali.DataAccess.RavenDB
{
    public class RavenModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IEventsService>().To<RavenEventsService>();
        }
    }
}
