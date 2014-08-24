using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Capercali.Entities;

namespace Capercali.WPF.ViewModel
{
    public interface IEventPageViewModel
    {
        Event Event { get; }
        string EventName { get; set; }
        TimeSpan EventZeroTime { get; }
        ObservableCollection<Course> Courses { get; set; }
    }
}