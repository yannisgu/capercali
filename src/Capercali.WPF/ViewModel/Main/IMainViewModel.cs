using System.Collections.Generic;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.Main
{
    public interface IMainViewModel : IRoutableViewModel
    {
        ReactiveList<Event> Events { get; set; }
        bool IsEventSelected { get; }
        Event SelectedEvent { get; set; }
        ReactiveCommand OpenEvent { get; }
        ReactiveCommand NewEvent { get; }
        ReactiveCommand DeleteEvent { get; }
    }
}