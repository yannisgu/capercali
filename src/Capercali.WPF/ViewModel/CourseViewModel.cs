using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using Capercali.Entities;
using Ninject.Activation.Strategies;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public class CourseViewModel:ReactiveObject
    {
        public CourseViewModel(Course course)
        {
            Name = course.Name;
            Controls = new ReactiveList<ControlViewModel>(course.Controls.Select(c => new ControlViewModel(c)));
            Init();
        }

        private void Init()
        {
            this.WhenAnyObservable(x => x.Controls.BeforeItemsAdded).
                Subscribe(_ =>
                {
                    _.Course = this;
                });
        }

        public CourseViewModel()
        {
            Controls = new ReactiveList<ControlViewModel>();
            Init();
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
