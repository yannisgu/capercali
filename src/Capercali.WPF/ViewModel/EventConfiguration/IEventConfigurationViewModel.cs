using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public interface IEventConfigurationViewModel
    {
        Event Event { get; }
        string EventName { get; set; }
        TimeSpan EventZeroTime { get; }
        ReactiveList<CourseViewModel> Courses { get; }
        CourseViewModel SelectedCourse { get; set; }
        ReactiveList<ControlViewModel> Controls { get; }

        int SelectedControlIndex { set; get; }
        ReactiveCommand ControlUp { get; }
        ReactiveCommand ControlDown { get; }
    }
}
