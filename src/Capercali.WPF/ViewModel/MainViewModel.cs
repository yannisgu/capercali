using System.Collections.Generic;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Capercali.WPF.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Capercali.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IEventsService eventsService;
        private readonly INavigation navigation;
        private IEnumerable<Event> events;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IEventsService eventsService, INavigation navigation)
        {
            this.eventsService = eventsService;
            this.navigation = navigation;

            Load(eventsService);
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        public RelayCommand OpenEvent
        {
            get { return openEvent ?? (openEvent = new RelayCommand(DoOpenEvent)); }
        }

        public RelayCommand NewEvent
        {
            get { return newEvent ?? (newEvent = new RelayCommand(DoNewEvent)); }
        }

        private void DoNewEvent()
        {
            throw new System.NotImplementedException();
        }

        private void DoOpenEvent()
        {
            navigation.Open<Pages.EventPage>();
        }

        private async void Load(IEventsService eventsService)
        {
            
            Events = await eventsService.GetAll();
        }

        public string FullName { get; set; }

        public IEnumerable<Event> Events
        {
            get { return events; }
            set { Set(() => Events, ref events, value); }
        }

        public bool IsEventSelected
        {
            get {return SelectedEvent != null; }
        }

        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                Set(() => SelectedEvent, ref selectedEvent, value);
                base.RaisePropertyChanged(() => IsEventSelected);
            }
        }

        private RelayCommand openEvent;
        private Event selectedEvent;

        public RelayCommand newEvent { get; set; }
    }
}