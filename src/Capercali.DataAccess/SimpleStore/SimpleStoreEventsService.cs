using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using Capercali.DataAccess.Services;
using Capercali.Entities;

namespace Capercali.DataAccess.SimpleStore
{
    public class SimpleStoreEventsService : SimpleStoreBaseService, IEventsService
    {
        public async Task<IEnumerable<Event>> GetAll()
        {
           return await BlobCache.LocalMachine.GetObject<IEnumerable<Event>>("events").Catch(Observable.Return(new List<Event>()) );
            
        }

        public async Task UpdateEvent(Event @event)
        {
            var events = new List<Event>(await GetAll());            
            if (events.Any(e => e.Id == @event.Id))
            {
                events.RemoveAll(e => e.Id == @event.Id);
                events.Add(@event);
            }
            else
            {
                var lastOrDefault = events.OrderBy(e => e.Id).LastOrDefault();
                @event.Id = lastOrDefault != null ? lastOrDefault.Id + 1 : 1;
                events.Add(@event);
            }
            await BlobCache.LocalMachine.InsertObject("events", events);
        }
    }
}