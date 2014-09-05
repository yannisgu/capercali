using System;
using System.Collections.Generic;
using System.Reactive.Linq;
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

        private ObservableAsPropertyHelper<bool> isEnabledProperty; 
        public bool IsEnabled { get { return isEnabledProperty.Value; } }

        public EditEventRunnerViewModel(EventRunner runner, IReactiveDerivedList<Course> courses)
        {
            this.Courses = courses;

            isEnabled = this.ObservableForProperty(_ => _.Runner).Select(_ => _.Value != null);
            isEnabled.ToProperty(this, _ => _.IsEnabled, out isEnabledProperty);

            Runner = runner;
            InitCommands();
        }

        private void InitCommands()
        {
            Save = new ReactiveCommand(isEnabled);
            Cancel = new ReactiveCommand(isEnabled);

        }

        public ReactiveCommand Cancel { get; private set; }

        private EventRunner runner;
        private IObservable<bool> isEnabled;

        public EventRunner Runner
        {
            get { return runner; }
            set { this.RaiseAndSetIfChanged(ref runner, value); }
        }

        public ReactiveCommand Save { get; private set; }
    }
}