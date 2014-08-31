using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capercali.Entities
{
    public class EventRunner : Runner
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan FinishTime {get;set;}

        public TimeSpan TotalTime
        {
            get
            {
                return FinishTime - StartTime;
            }
        }


        public long CourseId { get; set; }
        public long CategoryId { get; set; }

        public IEnumerable<Punch> Punches {get;set;}

        public RunnerStatus Status {get;set;}

    }
}
