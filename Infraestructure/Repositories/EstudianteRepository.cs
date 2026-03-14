using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly AppDbContext _context;

        public EstudianteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Estudiante>> GetAllAsync()
            => await _context.Estudiantes.AsNoTracking().ToListAsync();

        public async Task<Estudiante?> GetByIdAsync(int id)
            => await _context.Estudiantes.FindAsync(id);

        public async Task<Estudiante> AddAsync(Estudiante estudiante)
        {
            try
            {
                _context.Estudiantes.Add(estudiante);
                await _context.SaveChangesAsync();
                return estudiante;
            }
            catch (DbUpdateException ex)
            {
                // Revisamos si la excepción interna es por la restricción de clave única
                if (ex.InnerException != null && ex.InnerException.Message.Contains("UNIQUE KEY"))
                {
                    // Lanzamos una excepción controlada con un mensaje para el usuario
                    throw new Exception("Ya existe un estudiante registrado con esta cédula.");
                }

                // Si es otro error de base de datos, dejamos que fluya normalmente
                throw;
            }
        }

        public async Task UpdateAsync(Estudiante estudiante)
        {
            try
            {
                _context.Estudiantes.Update(estudiante);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex) {
                // Revisamos si la excepción interna es por la restricción de clave única
                if (ex.InnerException != null && ex.InnerException.Message.Contains("UNIQUE KEY"))
                {
                    // Lanzamos una excepción controlada con un mensaje para el usuario
                    throw new Exception("Ya existe un estudiante registrado con esta cédula.");
                }

                // Si es otro error de base de datos, dejamos que fluya normalmente
                throw;
            }
            

        }

        public async Task DeleteAsync(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null) return;
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();
        }

    }
}
