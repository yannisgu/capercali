using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capercali.Entities
{
    public class Runner : IEntity
    {
        public long Id
        {
            get;
            set;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int SiNumber { get; set; }

        public string Club { get; set; }

        public string Adress { get; set; }
        public string PLZ { get; set; }
        public string Location { get; set; }

        public string Email { get; set; }


    
    }
}
