using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class Client
    {
        public int Id { get; set; }
        public string client { get; set; }
        public string endpoint { get; set; }
        public string p256dh { get; set; }
        public string auth { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
