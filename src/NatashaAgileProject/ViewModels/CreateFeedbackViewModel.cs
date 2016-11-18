using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using System.ComponentModel.DataAnnotations;
using NatashaAgileProject.Models;

namespace NatashaAgileProject.ViewModels
{
    public class CreateFeedbackViewModel
    {
        public int FeedbackId { get; set; }       
        [Required]
        public string Description { get; set; }
        public string UserName { get; set; }

        //Relationship
        public int PackageId { get; set; }
        public Package Package { get; set; }

    }
}
