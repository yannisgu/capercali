using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.Entities;

namespace Capercali.DataAccess.Services
{
   public interface IEventsService
   {
       Task<IEnumerable<Event>> GetAll();
       Task UpdateEvent(Event @event);
   }
}
