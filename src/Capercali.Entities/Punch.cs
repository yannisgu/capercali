using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capercali.Entities
{
    public class Punch : IEntity

    {
        public long Id
        {
            get;
            set;
        }

        public TimeSpan Time { get; set; }
        public string ControlNumber { get; set;}
    }
}
