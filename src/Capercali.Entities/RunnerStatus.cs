using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capercali.Entities
{
    public enum RunnerStatus
    {
        Ok = 1,
        Misspunch = 2,
        Disqualified = 4,
        Overtime = 8,
        GiveUp = 16
    }
}
