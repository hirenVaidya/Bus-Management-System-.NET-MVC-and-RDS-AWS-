namespace Bus_Management_System.Data
using Bus_Management_System.Models;
using shuttle.Models;
using System.Collections.Generic;

namespace shuttle.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<LeadDetailsEntity> LeadDetails { get; set; }
    }
}