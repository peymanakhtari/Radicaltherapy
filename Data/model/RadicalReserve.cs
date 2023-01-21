using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class RadicalReserve
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public byte[] ReseptPic { get; set; }
        public int PayStatus  { get; set; }
        public int Price { get; set; }
        public string RegectionReason { get; set; }
        public string Refid { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
