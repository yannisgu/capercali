using System.Collections.Generic;

namespace Capercali.WPF.ViewModel.EventWindowCommands
{
    public interface IEventWindowCommands

    {
        IDictionary<string, string> Ports { get; }
    }
}