using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
            this.ObservableForProperty(x => x.EventName)
                .Merge<object>(this.ObservableForProperty(x => x.EventZeroTime))
                .Subscribe(async x =>
                {
                    Event.Name = EventName;
                    Event.ZeroTime = EventZeroTime;
                    await eventsService.UpdateEvent(Event);
                });
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

        private ObservableCollection<Course> courses;
        private Course selectedCourse;
        private TimeSpan eventZeroTime;

        public ObservableCollection<Course> Courses
        {
            get
            {
                if (courses == null)
                {
                    //courses = new ObservableCollection<Course>(Event.Courses ?? new List<Course>());
                    //courses.CollectionChanged += (s, e) =>
                    //{
                    //    Event.Courses = courses;
                    //};

                }
                return courses;
            }
            set
            {
                
            }
        }

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                //Set(() => SelectedCourse, ref selectedCourse, value);
                //RaisePropertyChanged(() => Controls);
            }
        }

        public ObservableCollection<Control> Controls
        {
            get
            {
                ObservableCollection<Control> controls = null;
                if (SelectedCourse != null)
                {
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
                }
                return controls; 
            
            }
        }

        public string UrlPathSegment { get { return "eventDetail"; }}
        public IScreen HostScreen { get; private set; }
    }
}