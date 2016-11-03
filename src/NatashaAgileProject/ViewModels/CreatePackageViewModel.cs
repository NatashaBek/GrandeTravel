using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using System.ComponentModel.DataAnnotations;

namespace NatashaAgileProject.ViewModels
{
    public class CreatePackageViewModel
    {
        [Required]
        public int PackageId { get; set; }

        [Required]
        public string PackageName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
