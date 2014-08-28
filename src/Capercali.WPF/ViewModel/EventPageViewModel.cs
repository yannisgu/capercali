using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    internal class EventPageViewModel : ReactiveObject, IEventPageViewModel
    {
        private readonly IMainViewModel mainViewModel;
        private readonly IEventsService eventsService;
        private readonly IEventConfigurationService coursesService;

        public EventPageViewModel(IMainViewModel mainViewModel, IEventsService eventsService,
            IEventConfigurationService coursesService, IScreen screen)
        {
            HostScreen = screen;
            this.mainViewModel = mainViewModel;
            this.eventsService = eventsService;
            this.coursesService = coursesService;
            Event = mainViewModel.SelectedEvent;
            EventName = Event.Name;
            EventZeroTime = Event.ZeroTime;
            InitCourses();
            this.ObservableForProperty(x => x.EventName)
                .Merge<object>(this.ObservableForProperty(x => x.EventZeroTime))
                .Subscribe(async x =>
                {
                    Event.Name = EventName;
                    Event.ZeroTime = EventZeroTime;
                    await eventsService.UpdateEvent(Event);
                });
            this.ObservableForProperty(x => x.SelectedCourse).
                Select(x => x.Value != null ? x.Value.Controls : null).
                ToProperty(this, model => model.Controls, out controls);

            var controlUpEnabled = this.WhenAny(x => x.SelectedControlIndex, x => x.Value != null && x.Value > 0);

            var controlDownEnabled = this.WhenAny(x => x.SelectedControlIndex, x => x.Value != null && x.Value > -1 && x.Value + 1 < (Controls == null ? 0 : Controls.Count));

            ControlUp = new ReactiveCommand(controlUpEnabled);
            ControlUp.Subscribe(_ => { this.Controls.Move((int)SelectedControlIndex, (int)SelectedControlIndex - 1); });
            ControlDown = new ReactiveCommand(controlDownEnabled);
            ControlDown.Subscribe(_ => { this.Controls.Move((int)SelectedControlIndex, (int)SelectedControlIndex + 1); });


        }

        private async void InitCourses()
        {

            courseChanged = new Subject<CourseViewModel>();
            courseChanged.Subscribe(_ => coursesService.UpdateCourse(Event.Id, _.ToCourse()));

            Courses =
                new ReactiveList<CourseViewModel>(
                    (await coursesService.GetCourses(Event.Id)).Select(_ => new CourseViewModel(_)));
            foreach (var course in Courses)
            {
                BindCourse(course);
            }

            Courses.ChangeTrackingEnabled = true;
            Courses.ItemChanged.Select(_ => _.Sender)
                .Merge(Courses.ItemsAdded)
                .Subscribe(courseChanged.OnNext);
            Courses.ItemsAdded.Subscribe(BindCourse);



        }

        private void BindCourse(CourseViewModel course)
        {
            course.Controls.ItemsAdded.Select(x => course)
                .Merge(course.Controls.ItemsRemoved.Select(x => course))
                .Merge(course.Controls.ItemsMoved.Select(x => course))
                .Merge(course.Controls.ItemChanged.Select(x => course))
                .Subscribe(courseChanged.OnNext);
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
        private Subject<CourseViewModel> courseChanged;
        private int selectedControl;

        public ReactiveList<ControlViewModel> Controls { get { return controls.Value; } }

        public int SelectedControlIndex
        {
            set
            {
                this.RaiseAndSetIfChanged(ref selectedControl, value);
            }
            get { return selectedControl; }
        }

        public ReactiveCommand ControlDown { get; protected set; }
        public ReactiveCommand ControlUp { get; protected set; }
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