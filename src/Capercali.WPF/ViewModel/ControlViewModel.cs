using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public class ControlViewModel : ReactiveObject
    {
        public ControlViewModel(Control control) : this()
        {
            ControlNumber = control.ControlNumber;
        }

        public ControlViewModel()
        {
            
            //this.ObservableForProperty(_ => _.Course).Select(_ => _.Value)
            //    .Merge(Course.Controls.ItemsAdded.Select(x => Course)).
            //    .Merge(Course.Controls.ItemsAdded.Select(x => Course));

            this.WhenAny(_ => _.Course, _ => _.Value).
                Subscribe(_ =>
            {
                if (Course != null)
                {
                    Course.Controls.ItemsAdded.Merge(Course.Controls.ItemsRemoved).
                        Merge(Course.Controls.ItemsMoved.Select(im => im.MovedItems.FirstOrDefault()))
                        .Select(i => Course.Controls.IndexOf(this) + 1)
                        .ToProperty(this, i => i.Number, out number, Course.Controls.IndexOf(this) + 1);

                    
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
            get { return number == null ? 0 : number.Value; }
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