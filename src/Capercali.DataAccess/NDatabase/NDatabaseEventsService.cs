using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using NDatabase;
using NDatabase.Api;

namespace Capercali.DataAccess.NDatabase
{
    public class NDatabaseEventsService : NDatabaseBaseService, IEventsService
    {
        public Task<IEnumerable<Event>> GetAll()
        {
            return Run<IEnumerable<Event>>(db => db.AsQueryable<Event>().ToList());
        }

        public Task UpdateEvent(Event @event)
        {
            return Run(db =>
            {
                Event updateEvent;
                if (@event.Id != 0)
                {
                    updateEvent = (Event)db.GetObjectFromId(OIDFactory.BuildObjectOID(@event.Id));
                    CopyValues(@event, updateEvent);
                    
                }
                else
                {
                    updateEvent = @event;
                }
                db.Store(updateEvent);
                
                db.Commit();

            });
        }

        private void CopyValues(object object1, object object2)
        {
            var props = object1.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.CanWrite)
                {
                    prop.SetValue(object2, prop.GetValue(object1));
                }
            }
        }
    }
}