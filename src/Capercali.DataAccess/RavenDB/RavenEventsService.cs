using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Raven.Client;

namespace Capercali.DataAccess.RavenDB
{
    public class RavenEventsService : RavenService, IEventsService
    {
        public async Task<IEnumerable<Event>> GetAll()
        {
            return await Session.Query<Event>().ToListAsync();
        }

        public async Task UpdateEvent(Event @event)
        {
            try
            {
                await Session.StoreAsync(@event);
                await Session.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
        }
    }
}