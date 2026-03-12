using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
        Task<Estudiante?> GetByCedulaAsyznc(string cedula);
        Task<Estudiante> AddAsync(Estudiante estudiante);
        Task<Estudiante> UpdateAsync(Estudiante estudiante);
        Task<Estudiante> DeleteAsync(int id);
    }
}
