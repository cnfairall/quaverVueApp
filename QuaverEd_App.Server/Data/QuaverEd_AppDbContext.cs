using Microsoft.EntityFrameworkCore;

namespace QuaverEd_App.Data
{
    public class QuaverEd_AppDbContext : DbContext
    {
        public QuaverEd_AppDbContext(DbContextOptions<QuaverEd_AppDbContext> options) : base(options)
        {

        }
        public DbSet<QuaverEd_App.Server.Models.Repository> Repository { get; set; } = default!;
    }
}