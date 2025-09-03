using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shuttle.Areas.Identity.Data;

namespace shuttle.Data
{
    public class shuttleContext : IdentityDbContext<shuttleUser>
    {
        public shuttleContext(DbContextOptions<shuttleContext> options) : base(options) { }
    }
}