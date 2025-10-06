using Hesol.Models;
using Microsoft.EntityFrameworkCore;


namespace Hesol.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Local> Local { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
