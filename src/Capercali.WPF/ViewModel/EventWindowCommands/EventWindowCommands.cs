using System.Collections.Generic;
using System.Management;

namespace Capercali.WPF.ViewModel.EventWindowCommands
{
    public class EventWindowCommands : IEventWindowCommands
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
            foreach (var item in searcher.Get())
            {
                ports[item["DeviceID"].ToString()] = item["Caption"].ToString();
            }

            Ports = ports;
        }

        public IDictionary<string, string> Ports { get; private set; }
    }
}