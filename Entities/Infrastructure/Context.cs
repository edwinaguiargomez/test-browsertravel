using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Autor> Autor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new DBConfig().GetStringConnection());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().ToTable("autores");
            base.OnModelCreating(modelBuilder);
        }

    }
}
