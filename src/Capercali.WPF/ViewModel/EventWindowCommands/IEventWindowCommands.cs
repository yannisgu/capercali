using System.Collections;
using System.Collections.Generic;

namespace Capercali.WPF.ViewModel
{
    public interface IEventWindowCommands

    {
        IDictionary<string, string> Ports { get; }
    }
}