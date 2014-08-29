using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Akavache;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Newtonsoft.Json;

namespace Capercali.DataAccess.SimpleStore
{
    public class SimpleStoreEventConfigurationService : SimpleStoreBaseService, IEventConfigurationService
    {
        public async Task<IEnumerable<Course>> GetCourses(long eventId)
        {
            return await Cache.GetObject<IEnumerable<Course>>("courses-" + eventId).Catch(Observable.Return(new List<Course>()));
        }

        public async Task UpdateCourse(long eventId, Course course)
        {
            await UpdateItem("courses-" + eventId, (await GetCourses(eventId)).ToList(), course);
        }

    }
}
