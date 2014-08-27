using System.Linq;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public class CourseViewModel:ReactiveObject
    {
        public CourseViewModel(Course course)
        {
            Name = course.Name;
            Controls = new ReactiveList<ControlViewModel>(course.Controls.Select(c => new ControlViewModel(c)));
        }

        public ReactiveList<ControlViewModel> Controls { get; private set; } 

        private string name;

        public string Name
        {
            get { return name; }
            set {this.RaiseAndSetIfChanged(ref name, value); }
        }

    }
}
