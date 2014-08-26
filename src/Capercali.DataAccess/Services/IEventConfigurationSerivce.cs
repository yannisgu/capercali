using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capercali.Entities;

namespace Capercali.DataAccess.Services
{
    public interface IEventConfigurationSerivce
    {
        Task LoadCourses(Event @event);
        Task UpdateCourses(Event @event);
        event CoursesChangedDelegate CoursesChanged;
    }

    public delegate void CoursesChangedDelegate(object sender, CoursesChangedArgs args);

    public class CoursesChangedArgs : EventArgs
    {
        public CoursesChangedArgs(IEnumerable<Course> courses, Event @event)
        {
            Event = @event;
            Courses = courses;
        }

        public IEnumerable<Course> Courses { get; private set; }
        public Event Event { get; private set; }
    }
}
