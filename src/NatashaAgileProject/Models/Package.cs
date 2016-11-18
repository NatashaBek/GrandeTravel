using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatashaAgileProject.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public bool Availability { get; set; }

        //Relationship
        public List<Feedback> Feedback { get; set; }
    }
}
