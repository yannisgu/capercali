using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.Entities;
using GalaSoft.MvvmLight.Command;

namespace Capercali.WPF.ViewModel
{
    public interface IMainViewModel
    {
        IEnumerable<Event> Events { get; set; }
        bool IsEventSelected { get; }
        Event SelectedEvent { get; set; }
        RelayCommand OpenEvent { get; }
        RelayCommand NewEvent { get; }
    }
}
