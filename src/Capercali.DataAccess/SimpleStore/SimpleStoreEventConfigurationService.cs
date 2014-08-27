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
    public class SimpleStoreEventConfigurationService : SimpleStoreBaseService, IEventConfigurationSerivce
    {
        public async Task<IEnumerable<Course>> GetCourses(long eventId)
        {
            return await Cache.GetObject<IEnumerable<Course>>("courses-" + eventId);
        }

        public async Task UpdateCourse(long eventId, Course course)
        {
            
        }
    }
}
