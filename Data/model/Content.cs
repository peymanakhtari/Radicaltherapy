using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class Content
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Text { get; set; }
        public byte[] Img { get; set; }
        public int Sequence { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
