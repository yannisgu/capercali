using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capercali.Entities
{
    public class Course :IEntity
    { 
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Control> Controls { get; set; }
    }
}
