using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Capercali.WPF.ViewModel.EventRunners
{
    public interface IEventRunnersViewModel
    {
        EditEventRunnerViewModel RegisterRunner { get; set; }
    }
}
