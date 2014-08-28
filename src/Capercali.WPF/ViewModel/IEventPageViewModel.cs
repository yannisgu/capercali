using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public interface IEventPageViewModel : IRoutableViewModel
    {
        Event Event { get; }
        string EventName { get; set; }
        TimeSpan EventZeroTime { get; }
        ReactiveList<CourseViewModel > Courses { get; }
        CourseViewModel SelectedCourse { get; set; }
        ReactiveList<ControlViewModel> Controls { get; }

        int SelectedControlIndex { set; get; }
        ReactiveCommand ControlUp { get; }
        ReactiveCommand ControlDown { get;}
    }
}