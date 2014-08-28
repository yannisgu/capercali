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
            var courses = (await GetCourses(eventId)).ToList();
            if (courses.Any(c => c.Id == course.Id))
            {
                courses.RemoveAll(e => e.Id == course.Id);
                courses.Add(course);
            }
            else
            {
                var lastOrDefault = courses.OrderBy(e => e.Id).LastOrDefault();
                course.Id = lastOrDefault != null ? lastOrDefault.Id + 1 : 1;
                courses.Add(course);
            }
            await Cache.InsertObject("courses-" + eventId, courses);
        }
    }
}
