using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using GalaSoft.MvvmLight;

namespace Capercali.WPF.ViewModel
{
    internal class EventPageViewModel:  ViewModelBase , IEventPageViewModel
    {
        private readonly IMainViewModel mainViewModel;
        private readonly IEventsService eventsService;

        public EventPageViewModel(IMainViewModel mainViewModel, IEventsService eventsService)
        {
            this.mainViewModel = mainViewModel;
            this.eventsService = eventsService;
            Event = mainViewModel.SelectedEvent;
        }

        public Event Event { get; private set; }

        public string EventName
        {
            get { return Event.Name; }
            set {
                SetEventValue(value, () => EventName, () => Event.Name);
            }
        }

        private async void SetEventValue<T, T2>(T value, Expression<Func<T2>> property, Expression<Func<T>>  setProperty)
        {
            if (!setProperty.Compile().Invoke().Equals(value))
            {
                RaisePropertyChanging(property);
                var name = GetPropertyName(setProperty);
                Event.GetType().GetProperty(name).SetValue(Event, value);
                await eventsService.UpdateEvent(Event);
                RaisePropertyChanged(property);
            }
        }

        public TimeSpan EventZeroTime
        {
            get { return Event.ZeroTime; }
            set { SetEventValue(value, () => EventZeroTime, () => Event.ZeroTime);}
        }

        private ObservableCollection<Course> courses;
        public ObservableCollection<Course> Courses
        {
            get { return courses ?? (courses = new ObservableCollection<Course>(Event.Courses ?? new List<Course>())); }
            set
            {
                
            }
        }
    }
}