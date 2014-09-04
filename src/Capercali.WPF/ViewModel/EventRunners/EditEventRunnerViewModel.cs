using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Capercali.WPF.ViewModel.Main;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.EventRunners
{
    public class EditEventRunnerViewModel : ReactiveObject
    {
        public IReactiveDerivedList<Course> Courses { get; private set; }
        public Event Event { get; set; }


        public EditEventRunnerViewModel(EventRunner runner, IReactiveDerivedList<Course> courses)
        {
            this.Courses = courses;
            Runner = runner;
            InitCommands();
        }

        private void InitCommands()
        {
            Save = new ReactiveCommand();
            Cancel = new ReactiveCommand();

        }

        public ReactiveCommand Cancel { get; private set; }

        private EventRunner runner;

        public EventRunner Runner
        {
            get { return runner; }
            set { this.RaiseAndSetIfChanged(ref runner, value); }
        }

        public ReactiveCommand Save { get; private set; }
    }
}