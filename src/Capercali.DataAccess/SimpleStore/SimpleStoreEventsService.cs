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
           return await Cache.GetObject<IEnumerable<Event>>("events").Catch(Observable.Return(new List<Event>()) );
        }

        public async Task UpdateEvent(Event @event)
        {
            await UpdateItem("events", (await GetAll()).ToList(), @event);
        }
    }
}