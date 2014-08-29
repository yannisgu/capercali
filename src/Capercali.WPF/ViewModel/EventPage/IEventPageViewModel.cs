using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel
{
    public interface IEventPageViewModel : IRoutableViewModel
    {
        IEventConfigurationViewModel EventConfiguration { get; } 
    }
}