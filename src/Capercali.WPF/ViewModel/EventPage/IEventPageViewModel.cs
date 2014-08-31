using Capercali.WPF.ViewModel.EventConfiguration;
using Capercali.WPF.ViewModel.EventRunners;
using Capercali.WPF.ViewModel.EventWindowCommands;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.EventPage
{
    public interface IEventPageViewModel : IRoutableViewModel
    {
        IEventConfigurationViewModel EventConfiguration { get; }

        IEventWindowCommands Commands { get; }

        IEventRunnersViewModel EventRunners { get; }
    }
}