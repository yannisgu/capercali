using ReactiveUI;
using System.Collections.Generic;
using System.Management;
using System.Linq;

namespace Capercali.WPF.ViewModel.EventWindowCommands
{
    public class EventWindowCommands : ReactiveObject, IEventWindowCommands
    {
        public EventWindowCommands()
        {
            Load();
        }

        private void Load()
        {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort");
            var ports = new Dictionary<string, string>();
            ports[""] = "Com-Port";
            foreach (var item in searcher.Get())
            {
                ports[item["DeviceID"].ToString()] = item["Caption"].ToString();
            }
            SelectedValue = ports.Where(p => p.Value.Contains("SPORTident")).Select(p => p.Key).FirstOrDefault() ?? "";
            Ports = ports;
        }

        public IDictionary<string, string> Ports { get; private set; }

        private string selectedValue;
        public string SelectedValue
        {
            get
            {
                return selectedValue;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref selectedValue, value);
            }
        }
    }
}