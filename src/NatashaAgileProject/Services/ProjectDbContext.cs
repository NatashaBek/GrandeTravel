using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//...
using Microsoft.EntityFrameworkCore;
using NatashaAgileProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NatashaAgileProject.Services
{
    public class ProjectDbContext : IdentityDbContext<User>
    {
        public DbSet<Package> Packages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=NBProjectDB; Trusted_Connection=True;");
        }
    }
}
