using Microsoft.EntityFrameworkCore;

namespace Seiton.Models
{
    public class AppDBContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);

        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public object Usuario { get; internal set; }
    }
}
