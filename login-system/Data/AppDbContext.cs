using login_system.Models;
using Microsoft.EntityFrameworkCore;

namespace login_system.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

    }
}
