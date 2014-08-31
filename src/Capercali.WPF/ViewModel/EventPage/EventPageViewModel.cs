using Capercali.WPF.ViewModel.EventConfiguration;
using Capercali.WPF.ViewModel.EventRunners;
using Capercali.WPF.ViewModel.EventWindowCommands;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.EventPage
{
    internal class EventPageViewModel : ReactiveObject, IEventPageViewModel
    {
        public EventPageViewModel(IScreen host)
        {
            HostScreen = host;
            EventConfiguration = (IEventConfigurationViewModel)RxApp.DependencyResolver.GetService(typeof (IEventConfigurationViewModel));
            EventRunners = (IEventRunnersViewModel)RxApp.DependencyResolver.GetService(typeof(IEventRunnersViewModel));
            Commands = new EventWindowCommands.EventWindowCommands();
        }

        public IEventConfigurationViewModel EventConfiguration { get; private set; }
        public IEventRunnersViewModel EventRunners { get; private set; }
        

        public IEventWindowCommands Commands {get; private set;}

        public string UrlPathSegment { get { return "eventDetail"; }}
        public IScreen HostScreen { get; private set; }
    }
}