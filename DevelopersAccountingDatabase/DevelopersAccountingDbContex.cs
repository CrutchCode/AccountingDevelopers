using System;
using DevelopersAccountingDatabase.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevelopersAccountingDatabase
{
    public class DevelopersAccountingDbContex : IdentityDbContext<User>
    {
        public DevelopersAccountingDbContex(DbContextOptions<DevelopersAccountingDbContex>options) 
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Developer> Developers { get; set; }
    }
}
