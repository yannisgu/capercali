using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Capercali.Entities;
using Raven.Client;

namespace Capercali.DataAccess.Services
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