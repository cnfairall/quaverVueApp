using Microsoft.EntityFrameworkCore;
using QuaverEd_App.Server.Models;

namespace QuaverEd_App.Data
{
    public class QuaverEd_AppDbContext : DbContext
    {
        public QuaverEd_AppDbContext(DbContextOptions<QuaverEd_AppDbContext> options) : base(options)
        {

        }
        public DbSet<Repository> Repository { get; set; } = default!;
    }
}