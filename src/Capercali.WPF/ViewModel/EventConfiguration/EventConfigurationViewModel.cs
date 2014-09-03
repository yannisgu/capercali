using System;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Capercali.WPF.ViewModel.Main;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.EventConfiguration
{
    public class EventConfigurationViewModel : ReactiveObject, IEventConfigurationViewModel
    {
        private readonly ObservableAsPropertyHelper<ReactiveList<ControlViewModel>> controls;
        private readonly IEventConfigurationService coursesService;
        private readonly IMainViewModel mainViewModel;
        private readonly IScreen screen;
        private Subject<CourseViewModel> courseChanged;
        private ReactiveList<CourseViewModel> courses;
        private string eventName;
        private TimeSpan eventZeroTime;
        private int selectedControl;
        private CourseViewModel selectedCourse;
        private Subject<CourseViewModel> courseDeleted;

        public EventConfigurationViewModel(IMainViewModel mainViewModel, IEventsService eventsService,
            IEventConfigurationService coursesService, IScreen screen)
        {
            this.mainViewModel = mainViewModel;
            this.coursesService = coursesService;
            this.screen = screen;
            Event = mainViewModel.SelectedEvent;
            EventName = Event.Name;
            EventZeroTime = Event.ZeroTime;
            InitCourses();
            this.WhenAny(x => x.EventName, x => x.EventZeroTime, (x, y) => x.Sender)
                .Subscribe(async x =>
                {
                    Event.Name = EventName;
                    Event.ZeroTime = EventZeroTime;
                    await eventsService.UpdateEvent(Event);
                });
            this.ObservableForProperty(x => x.SelectedCourse).
                Select(x => x.Value != null ? x.Value.Controls : null).
                ToProperty(this, model => model.Controls, out controls);

            IObservable<bool> controlUpEnabled = this.WhenAny(x => x.SelectedControlIndex, x => x.Value > 0);

            IObservable<bool> controlDownEnabled = this.WhenAny(x => x.SelectedControlIndex,
                x => x.Value > -1 && x.Value + 1 < (Controls == null ? 0 : Controls.Count));

            ControlUp = new ReactiveCommand(controlUpEnabled);
            ControlUp.Subscribe(_ => Controls.Move(SelectedControlIndex, SelectedControlIndex - 1));
            ControlDown = new ReactiveCommand(controlDownEnabled);
            ControlDown.Subscribe(_ => Controls.Move(SelectedControlIndex, SelectedControlIndex + 1));
        }

        public Event Event { get; private set; }

        public string EventName
        {
            get { return eventName; }
            set { this.RaiseAndSetIfChanged(ref eventName, value); }
        }


        public TimeSpan EventZeroTime
        {
            get { return eventZeroTime; }
            set { this.RaiseAndSetIfChanged(ref eventZeroTime, value); }
        }

        public ReactiveList<CourseViewModel> Courses
        {
            get { return courses; }
            protected set { this.RaiseAndSetIfChanged(ref courses, value); }
        }

        public CourseViewModel SelectedCourse
        {
            get { return selectedCourse; }
            set { this.RaiseAndSetIfChanged(ref selectedCourse, value); }
        }

        public ReactiveList<ControlViewModel> Controls
        {
            get { return controls.Value; }
        }

        public int SelectedControlIndex
        {
            set { this.RaiseAndSetIfChanged(ref selectedControl, value); }
            get { return selectedControl; }
        }

        public ReactiveCommand ControlDown { get; protected set; }
        public ReactiveCommand ControlUp { get; protected set; }

        private async void InitCourses()
        {
            courseChanged = new Subject<CourseViewModel>();
            courseChanged.Subscribe(async _ => _.Id = await coursesService.UpdateCourse(Event.Id, _.ToCourse()));
            courseDeleted = new Subject<CourseViewModel>();
            courseDeleted.Subscribe(async _ => await coursesService.DeleteCourse(Event.Id, _.ToCourse()));

            Courses =
                new ReactiveList<CourseViewModel>(
                    (await coursesService.GetCourses(Event.Id)).Select(_ => new CourseViewModel(_)));
            Courses.ForEach(BindCourse);

            Courses.ChangeTrackingEnabled = true;
            Courses.ItemChanged.Select(_ => _.Sender)
                .Merge(Courses.ItemsAdded)
                .Subscribe(courseChanged.OnNext);
            Courses.ItemsRemoved.Subscribe(courseDeleted.OnNext);
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
    }
}