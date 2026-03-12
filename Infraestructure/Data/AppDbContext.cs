using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>(e =>
            {
                e.ToTable("Estudiantes");
                e.HasKey(x => x.Id);
                e.Property(x => x.Cedula).HasMaxLength(10).IsRequired();
                e.Property(x => x.PrimerNombre).HasMaxLength(100).IsRequired();
                e.Property(x => x.SegundoNombre).HasMaxLength(100);
                e.Property(x => x.PrimerApellido).HasMaxLength(100).IsRequired();
                e.Property(x => x.SegundoApellido).HasMaxLength(100).IsRequired();
                e.Property(x => x.Ciudad).HasMaxLength(100).IsRequired();
                e.Property(x => x.FechaNacimiento).IsRequired();
            });
        }
    }

}
