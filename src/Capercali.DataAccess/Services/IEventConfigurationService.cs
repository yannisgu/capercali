using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capercali.Entities;

namespace Capercali.DataAccess.Services
{
   public  interface IEventConfigurationService
    {
        Task<IEnumerable<Course>> GetCourses(long eventId);
        Task UpdateCourse(long eventId, Course course);


    }
}
