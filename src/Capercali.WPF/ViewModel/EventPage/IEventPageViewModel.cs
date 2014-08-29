using Capercali.WPF.ViewModel.EventConfiguration;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.EventPage
{
    public interface IEventPageViewModel : IRoutableViewModel
    {
        IEventConfigurationViewModel EventConfiguration { get; } 
    }
}