using System.Collections.Generic;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public interface IMainViewModel : IRoutableViewModel
    {
        IEnumerable<Event> Events { get; set; }
        bool IsEventSelected { get; }
        Event SelectedEvent { get; set; }
        ReactiveCommand OpenEvent { get; }
        ReactiveCommand NewEvent { get; }
    }
}