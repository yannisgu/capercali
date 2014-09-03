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
    public class SimpleStoreEventConfigurationService : SimpleStoreEventChildBaseService<Course>, IEventConfigurationService
    {
        public async Task<IEnumerable<Course>> GetCourses(long eventId)
        {
            return await Get(eventId);
        }

        public async Task<long> UpdateCourse(long eventId, Course course)
        {
            return await Update(eventId, course);
        }

        public async Task DeleteCourse(long eventId, Course course)
        {
            await Delete(eventId, course);
        }

        public override string Key
        {
            get { return "courses-"; }
        }
    }
}
