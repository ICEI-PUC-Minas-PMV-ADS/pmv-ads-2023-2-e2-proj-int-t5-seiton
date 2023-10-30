using Microsoft.EntityFrameworkCore;

namespace Seiton.Models
{
    public class AppDBContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.Id);

        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public object Usuario { get; internal set; }

        public DbSet<Projeto> Projetos { get; set; }
        public object Projeto { get; internal set; }

        public DbSet<Colunas> Colunas { get; set; }
        public object Coluna { get; internal set; }

        public DbSet<Tarefas> Tarefas { get; set; }
        public object Tarefa { get; internal set; }

    }
}
