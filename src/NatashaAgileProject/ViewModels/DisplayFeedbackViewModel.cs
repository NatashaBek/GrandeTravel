using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using NatashaAgileProject.Models;

namespace NatashaAgileProject.ViewModels
{
    public class DisplayFeedbackViewModel
    {
        public int PacId { get; set; }
        public string PacName { get; set; }
       
        public IEnumerable<Feedback> PacFeedback { get; set; }

    }
}
