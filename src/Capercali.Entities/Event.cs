using System;
using System.Collections;
using System.Collections.Generic;
using NDatabase.Api;

namespace Capercali.Entities
{
    public class Event : IEntity
    {
        public string Name { get; set; }

        public long Id { get; set; }

        public TimeSpan ZeroTime { get; set; }
    }
}