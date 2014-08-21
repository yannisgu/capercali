/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Capercali.WPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.ComponentModel;
using Capercali.DataAccess.RavenDB;
using CommonServiceLocator.NinjectAdapter;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace Capercali.WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var container = new StandardKernel();
            if (ViewModelBase.IsInDesignModeStatic)
            {
                container.Load(new DesignTimeDataModule());
            }
            else
            {
                container.Load(new RavenModule());
            }
            container.Load(new ViewModelModule());
            // Set the Ninject Kernel as the ServiceLocatorProvider to make it Resolve our ViewModels (and their dependencies)
            var serviceLocator = new NinjectServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public IMainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IMainViewModel>();
            }
        }

        public IEventPageViewModel Event
        {
            get { return ServiceLocator.Current.GetInstance<IEventPageViewModel>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}