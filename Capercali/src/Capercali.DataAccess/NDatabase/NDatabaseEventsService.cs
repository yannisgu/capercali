using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Capercali.DataAccess.Services;
using Capercali.Entities;

namespace Capercali.DataAccess.NDatabase
{
    public class NDatabaseEventsService : NDatabaseBaseService, IEventsService
    {
        public async Task<IEnumerable<Event>> GetAll()
        {
            return new List<Event>();
        }

        public async Task UpdateEvent(Event @event)
        {
         
        }
    }
}