using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public  string UserName { get; set; }
        public bool UserNameType { get; set; }
        public string WhatsApp { get; set; }
        public ICollection<RadicalReserve> RadicalReserves { get; set; }


    }
}
