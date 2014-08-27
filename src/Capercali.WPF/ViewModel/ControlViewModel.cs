using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public class ControlViewModel : ReactiveObject
    {
        public ControlViewModel(Control control)
        {
            ControlNumber = control.ControlNumber;
        }

        public ControlViewModel()
        {
            this.WhenAny(_ => _.Course, _ => _.Value).
                Subscribe(_ =>
            {
                if (_ != null)
                {
                    _.Controls.ItemsAdded.Merge(Course.Controls.ItemsRemoved)
                        .Select(i => _.Controls.IndexOf(this) + 1)
                        .ToProperty(this, i => i.Number, out number);
                }
            });


        }

        public CourseViewModel Course
        {
            get { return course; }
            set { this.RaiseAndSetIfChanged(ref course, value); }
        }

        private string controlNumber;
        private CourseViewModel course;

        private ObservableAsPropertyHelper<int> number; 

        public int Number
        {
            get { return number.Value; }
        }

        public string ControlNumber
        {
            get { return controlNumber; }
            set { this.RaiseAndSetIfChanged(ref controlNumber, value); }
        }

        public Control ToModel()
        {
            return new Control(){ControlNumber = ControlNumber, Number = Number};
        }
    }
}