using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NatashaAgileProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date {get; set;}

        //Package       
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        
        //User
        public string UserName { get; set; }
    }
}
