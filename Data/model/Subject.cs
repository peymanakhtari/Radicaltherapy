using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Tite{ get; set; }
        public string English { get; set; }
        public string SmallText{ get; set; }
        public string CoverPic { get; set; }
        public int Sequence { get; set; }
        public ICollection<Content> Contents { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
