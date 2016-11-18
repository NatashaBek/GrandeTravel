using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatashaAgileProject.ViewModels
{
    public class UpdatePackageDetailsViewModel
    {
        public string Location { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public bool Availability { get; set; }
    }
}
