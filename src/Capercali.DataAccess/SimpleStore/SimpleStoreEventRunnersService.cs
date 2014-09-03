using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using Capercali.DataAccess.Services;
using Capercali.Entities;

namespace Capercali.DataAccess.SimpleStore
{
    public class SimpleStoreEventRunnersService : SimpleStoreEventChildBaseService<EventRunner>, IEventRunnersService
    {
        

        public async Task<IEnumerable<EventRunner>> GetRunners(long eventId)
        {
            return await Get(eventId);
        }

        public async  Task<long> UpdateRunners(long eventId, EventRunner runner)
        {
            return await Update(eventId, runner);
        }

        public async Task DeleteRunners(long eventId, EventRunner runner)
        {
            await Delete(eventId, runner);
        }


        public override string Key
        {
            get { return "runners-"; }
        }
    }
}
