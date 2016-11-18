using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using NatashaAgileProject.Models;

namespace NatashaAgileProject.ViewModels
{
    public class AddOrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }

        //Package
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public Package Packages { get; set; }

        //User
        public string UserName { get; set; }
    }
}
