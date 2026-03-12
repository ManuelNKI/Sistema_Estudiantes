using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;

namespace Infraestructure.Repositories
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly AppDbContext _context;
        public Task<Estudiante> AddAsync(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Estudiante>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante?> GetByCedulaAsyznc(string cedula)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Estudiante> UpdateAsync(Estudiante estudiante)
        {
            throw new NotImplementedException();
        }
    }
}
