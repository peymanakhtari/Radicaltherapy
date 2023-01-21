using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadicalTherapy.Data.model
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        public int subjectId { get; set; }
        public int ClientID { get; set; }
        public bool Status { get; set; }
        public bool Checked { get; set; }
        public Client Client { get; set; }
        public Subject Subject { get; set; }
    }
}
