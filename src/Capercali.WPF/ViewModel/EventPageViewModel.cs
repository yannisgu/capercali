using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reactive.Linq;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    internal class EventPageViewModel : ReactiveObject, IEventPageViewModel
    {
        private readonly IMainViewModel mainViewModel;
        private readonly IEventsService eventsService;

        public EventPageViewModel(IMainViewModel mainViewModel, IEventsService eventsService, IScreen screen)
        {


            HostScreen = screen;
            this.mainViewModel = mainViewModel;
            this.eventsService = eventsService;
            Event = mainViewModel.SelectedEvent;
            EventName = Event.Name;
            EventZeroTime = Event.ZeroTime;
            Courses = new ReactiveList<CourseViewModel>();
            this.ObservableForProperty(x => x.EventName)
                .Merge<object>(this.ObservableForProperty(x => x.EventZeroTime))
                .Subscribe(async x =>
                {
                    Event.Name = EventName;
                    Event.ZeroTime = EventZeroTime;
                    await eventsService.UpdateEvent(Event);
                });
            this.ObservableForProperty(x => x.SelectedCourse).
                Select(x =>
                {

                    var val = x.Value != null ? x.Value.Controls : null;
                    Debug.WriteLine(val);
                    return val;
                }).
                ToProperty(this, model => model.Controls, out controls);
        }

        public Event Event { get; private set; }

        private string eventName;

        public string EventName
        {
            get { return eventName; }
            set
            {
                this.RaiseAndSetIfChanged(ref eventName, value);
            }
        }


        public TimeSpan EventZeroTime
        {
            get { return eventZeroTime; }
            set { this.RaiseAndSetIfChanged(ref eventZeroTime, value); }
        }

        private CourseViewModel selectedCourse;
        private TimeSpan eventZeroTime;
        private ReactiveList<CourseViewModel> courses;

        public ReactiveList<CourseViewModel> Courses
        {
            get { return courses; }
            protected set { this.RaiseAndSetIfChanged(ref courses, value); }
        }

        public CourseViewModel SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedCourse, value);
            }
        }

        ObservableAsPropertyHelper<ReactiveList<ControlViewModel>> controls;

        public ReactiveList<ControlViewModel> Controls { get { return controls.Value; } }
        //controls = new ObservableCollection<Control>(SelectedCourse.Controls ?? new List<Control>());
        //controls.CollectionChanged += (s, e) =>
        //{
        //    int i = 1;
        //    foreach (var control in controls)
        //    {
        //        control.Number = i++;
        //    }
        //    SelectedCourse.Controls = controls;
        //    eventsService.UpdateEvent(Event);
        //};

        public string UrlPathSegment { get { return "eventDetail"; }}
        public IScreen HostScreen { get; private set; }
    }
}