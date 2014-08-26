using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.DataAccess.SimpleStore;
using Capercali.WPF.Pages;
using Ninject;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public interface IAppBootstrapper : IScreen { }

    public class AppBootstrapper : ReactiveObject, IAppBootstrapper
    {
        public IRoutingState Router { get; private set; }
        public AppBootstrapper(IMutableDependencyResolver dependencyResolver = null, IRoutingState testRouter = null)
        {
            Router = testRouter ?? new RoutingState();
        
            RxApp.DependencyResolver = new NinjectDependencyResolver();
            RxApp.MutableResolver.InitializeResolver();
            dependencyResolver = dependencyResolver ?? RxApp.MutableResolver;
            RegisterParts(dependencyResolver);
            
            
            LogHost.Default.Level = LogLevel.Debug;
            
            Router.Navigate.Execute(dependencyResolver.GetService(typeof(IMainViewModel)));
        }

        

        private void RegisterParts(IMutableDependencyResolver dependencyResolver)
        {
            dependencyResolver.RegisterConstant(this, typeof(IScreen));
            dependencyResolver.Register(() => new EventPage(), typeof(IViewFor<EventPageViewModel>));
            dependencyResolver.Register(() => new EventSelectionPage(), typeof(IViewFor<MainViewModel>));
        }
    }

    public class NinjectDependencyResolver : IMutableDependencyResolver
    {
        private readonly StandardKernel container;

        public NinjectDependencyResolver()
        {
            container = new StandardKernel();
            /*if (ViewModelBase.IsInDesignModeStatic)
            {
                container.Load(new DesignTimeDataModule());
            }
            else
            {
                container.Load(new NDatabaseModule());
            }*/
            container.Load(new SimpleStoreModule());
            container.Load(new ViewModelModule());
        }

        public void Dispose()
        {
            
        }

        public object GetService(Type serviceType, string contract = null)
        {
          return  container.Get(serviceType, contract);
        }

        public IEnumerable<object> GetServices(Type serviceType, string contract = null)
        {
            return container.GetAll(serviceType, contract);
        }

        public void Register(Func<object> factory, Type serviceType, string contract = null)
        {
            if (contract != null)
            {
                container.Bind(serviceType).ToMethod(ctx => factory()).Named(contract);
            }
            else
            {
                container.Bind(serviceType).ToMethod(ctx => factory());
            }
        }
    }
}
