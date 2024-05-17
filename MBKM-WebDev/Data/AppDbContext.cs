using MBKM_WebDev.Models;
using Microsoft.EntityFrameworkCore;

namespace MBKM_WebDev.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
    }
}
