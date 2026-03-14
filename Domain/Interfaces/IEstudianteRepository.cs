using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
        Task<Estudiante> AddAsync(Estudiante estudiante);
        Task UpdateAsync(Estudiante estudiante);
        Task DeleteAsync(int id);
    }
}
