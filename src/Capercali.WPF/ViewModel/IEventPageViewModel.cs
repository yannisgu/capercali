using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public interface IEventPageViewModel : IRoutableViewModel
    {
        Event Event { get; }
        string EventName { get; set; }
        TimeSpan EventZeroTime { get; }
        ObservableCollection<Course> Courses { get; set; }
        Course SelectedCourse { get; set; }
        ObservableCollection<Control> Controls { get; }
    }
}