using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Capercali.DataAccess.Services;
using Capercali.Entities;
using Newtonsoft.Json;

namespace Capercali.DataAccess.SimpleStore
{
    public class SimpleStoreEventConfigurationService : SimpleStoreBaseService, IEventConfigurationSerivce
    {
        public async Task LoadCourses(Event @event)
        {
            var file = OpenFile(@event.Id, "configuration.json");
            file.Seek(0, SeekOrigin.Begin);
            var fileContent = new byte[file.Length];
            var buffer = new byte[64];
            MemoryStream stream = new MemoryStream();
            while (await file.ReadAsync(buffer, 0, buffer.Length) > 0)
            {
                stream.Write(buffer, 0, buffer.Length);
            }

            var bytes = stream.ToArray();
            var ev = JsonConvert.DeserializeObject<Event>(Encoding.UTF8.GetString(bytes));
            

        }

        public Task UpdateCourses(Event @event)
        {
            
            if (CoursesChanged != null)
            {
         //       CoursesChanged(this, new CoursesChangedArgs(@event.Courses, @event));
            }
            return Task.Run(() => { });
        }

        public event CoursesChangedDelegate CoursesChanged;
    }
}
