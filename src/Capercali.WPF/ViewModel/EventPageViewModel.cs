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
        public EventPageViewModel(IScreen host)
        {
            HostScreen = host;
            EventConfiguration = (IEventConfigurationViewModel)RxApp.DependencyResolver.GetService(typeof (IEventConfigurationViewModel));
        }

        public IEventConfigurationViewModel EventConfiguration { get; private set; } 

        public string UrlPathSegment { get { return "eventDetail"; }}
        public IScreen HostScreen { get; private set; }
    }
}