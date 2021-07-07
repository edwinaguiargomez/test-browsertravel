using Entities;
using Microsoft.EntityFrameworkCore;

namespace AssemblyStructure
{
    public class Context : DbContext
    {
        public DbSet<Autor> Autor { get; set; }
        public DbSet<AutoresHasLibros> AutoresHasLibros { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Libro> Libro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new DBConfig().GetStringConnection());
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Autor>().ToTable("autores");
        //    modelBuilder.Entity<AutoresHasLibros>().ToTable("autores_has_libros");
        //    modelBuilder.Entity<Editorial>().ToTable("editoriales");
        //    modelBuilder.Entity<Libro>().ToTable("libros");
        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
