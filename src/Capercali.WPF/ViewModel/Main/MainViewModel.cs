using System;
using System.Collections.Generic;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Capercali.WPF.ViewModel.EventPage;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.Main
{
    public class MainViewModel : ReactiveObject, IMainViewModel
    {
        private readonly IEventsService eventsService;
        private ReactiveList<Event> events;
        private Event selectedEvent;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IEventsService eventsService, IScreen screen)
        {
            HostScreen = screen;
            this.eventsService = eventsService;
            var openEventVisible =  this.WhenAny(x => x.SelectedEvent, e => e.Value != null);
            OpenEvent = new ReactiveCommand(openEventVisible, initialCondition:false);
            OpenEvent.Subscribe(DoOpenEvent);
            NewEvent = new ReactiveCommand();
            NewEvent.Subscribe(x =>
            {
                this.SelectedEvent = new Event();
                HostScreen.Router.Navigate.Execute(RxApp.DependencyResolver.GetService(typeof(IEventPageViewModel)));
            });
            DeleteEvent = new ReactiveCommand(openEventVisible, initialCondition: false);
            DeleteEvent
                .Subscribe(async _ => await eventsService.DeleteEvent(SelectedEvent));
            DeleteEvent.Subscribe(_ => Events.Remove(SelectedEvent));
            Load();
        }

        public ReactiveCommand DeleteEvent { get; private set; }

        private void DoOpenEvent(object obj)
        {
            HostScreen.Router.Navigate.Execute(RxApp.DependencyResolver.GetService(typeof(IEventPageViewModel)));
        }


        public ReactiveCommand NewEvent { get; protected set; }
        public ReactiveCommand DeleteeEvent { get; private set; }

        public ReactiveCommand OpenEvent { get; protected set; }


        public ReactiveList<Event> Events
        {
            get { return events; }
            set { this.RaiseAndSetIfChanged(ref events, value); }
        }

        public bool IsEventSelected
        {
            get { return SelectedEvent != null; }
        }

        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set { this.RaiseAndSetIfChanged(ref selectedEvent, value); }
        }

        private async void Load()
        {
            Events = new ReactiveList<Event>(await eventsService.GetAll());
        }

        public string UrlPathSegment { get { return "main"; } }
        public IScreen HostScreen { get; private set; }
    }
}