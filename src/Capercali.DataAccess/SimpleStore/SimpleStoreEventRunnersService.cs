using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        public SimpleStoreEventRunnersService(bool isCache = false) : base(isCache)
        {
            
        }

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

        public async Task<IEnumerable<EventRunner>> Search(long eventId, object searchKey)
        {
            if (searchKey != null)
            {
                var keys = searchKey.ToString().Split(' ').Select(_ => _.Trim().ToLower());
                var runners = (await GetRunners(eventId)).ToArray();
                return from r in runners
                        where keys.All(k => (new[] { r.FirstName, r.LastName, r.SiNumber.ToString() })
                            .Where(v => v != null)
                            .Select(v => v.ToLower()).Any(v => v.StartsWith(k)))
                        select r;
            }
            return new List<EventRunner>();
        }


        public override string Key
        {
            get { return "runners-"; }
        }
    }
}
