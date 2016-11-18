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
        public DbSet<Package> Package { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=NBProjectDB; Trusted_Connection=True;");
        }
    }
}
