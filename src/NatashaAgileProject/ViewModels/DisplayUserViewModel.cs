using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using NatashaAgileProject.Models;

namespace NatashaAgileProject.ViewModels
{
    public class DisplayUserViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}
