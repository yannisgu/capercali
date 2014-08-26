using System;
using System.Collections.Generic;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Capercali.WPF.Pages;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public class MainViewModel : ReactiveObject, IMainViewModel
    {
        private readonly IEventsService eventsService;
        private IEnumerable<Event> events;
        private Event selectedEvent;

        /// <summary>
        ///     Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IEventsService eventsService, IScreen screen)
        {
            HostScreen = screen;
            this.eventsService = eventsService;
            var openEventVisible =  this.WhenAny(x => x.SelectedEvent, e => e.Value != null);
            OpenEvent = new ReactiveCommand(openEventVisible);
            OpenEvent.Subscribe(DoOpenEvent);
            NewEvent = new ReactiveCommand();
            Load();
        }

        private void DoOpenEvent(object obj)
        {
            HostScreen.Router.Navigate.Execute(RxApp.DependencyResolver.GetService(typeof(IEventPageViewModel)));
        }


        public ReactiveCommand NewEvent { get; protected set; }

        public ReactiveCommand OpenEvent { get; protected set; }


        public IEnumerable<Event> Events
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
            await eventsService.UpdateEvent(new Event() {Name = "Test1"});
            Events = await eventsService.GetAll();
        }

        public string UrlPathSegment { get { return "main"; } }
        public IScreen HostScreen { get; private set; }
    }
}