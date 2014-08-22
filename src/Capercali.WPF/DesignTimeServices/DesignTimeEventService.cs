using System.Collections.Generic;
using System.Threading.Tasks;
using Capercali.DataAccess.Services;
using Capercali.Entities;

namespace Capercali.WPF.ViewModel
{
    internal class DesignTimeEventService : IEventsService
    {
        public Task<IEnumerable<Event>> GetAll()
        {
            var task = new Task<IEnumerable<Event>>(() => new[]
            {
                new Event {Name = "EventPage 1"},
                new Event {Name = "EventPage 2"}
            });
            task.Start();
            return task;
        }

        public Task UpdateEvent(Event @event)
        {
            return new Task(() => { });
        }
    }
}