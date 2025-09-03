using Bus_Management_System.Models;
using System.Collections.Generic;
using shuttle.Models;

namespace Bus_Management_System.Data
{
    public class AddBusDbContext : DbContext
    {
        public AddBusDbContext(DbContextOptions<AddBusDbContext> options) : base(options) { }

        public DbSet<AddBusEntity> AddBus { get; set; }
    }
}
