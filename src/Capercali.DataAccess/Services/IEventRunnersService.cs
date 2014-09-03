using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.Entities;

namespace Capercali.DataAccess.Services
{
    public interface IEventRunnersService
    {
        Task<IEnumerable<EventRunner>> GetRunners(long eventId);
        Task<long> UpdateRunners(long eventId, EventRunner runner);
        Task DeleteRunners(long eventId, EventRunner runner);
    }
}
