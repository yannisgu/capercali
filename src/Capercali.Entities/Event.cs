using System;
using System.Collections;
using System.Collections.Generic;
using NDatabase.Api;

namespace Capercali.Entities
{
    public class Event
    {
        public Event()
        {
            Courses = new List<Course>();
        }

        public string Name { get; set; }

        [OID] private long id;

        public long Id
        {
            get { return id; }
        }

        public List<Course> Courses { get; set; } 

        public TimeSpan ZeroTime { get; set; }
    }
}