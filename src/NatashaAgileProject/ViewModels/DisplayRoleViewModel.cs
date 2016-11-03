using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NatashaAgileProject.ViewModels
{
    public class DisplayRoleViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
