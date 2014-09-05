using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Capercali.Entities;
using ReactiveUI;

namespace Capercali.WPF.ViewModel.EventRunners
{
    public interface IEventRunnersViewModel
    {
        EditEventRunnerViewModel RegisterRunner { get; set; }

        string EditSearchTerm { get; set; }

        IEnumerable<EventRunnerSearchResult> EditSearchResults { get; } 
    }
}
