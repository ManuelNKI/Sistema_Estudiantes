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
                e.HasKey(x => x.id);
                e.Property(x => x.cedula).HasMaxLength(10).IsRequired();
                e.Property(x => x.primer_nombre).HasMaxLength(100).IsRequired();
                e.Property(x => x.segundo_nombre).HasMaxLength(100);
                e.Property(x => x.primer_apellido).HasMaxLength(100).IsRequired();
                e.Property(x => x.segundo_apellido).HasMaxLength(100).IsRequired();
                e.Property(x => x.ciudad).HasMaxLength(100).IsRequired();
                e.Property(x => x.fecha_nacimiento).IsRequired();
            });
        }
    }

}
