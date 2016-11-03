using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatashaAgileProject.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string Description { get; set; }

        //Relationship
        public int PackageId { get; set; }
        public Package Package { get; set; }

    }
}
