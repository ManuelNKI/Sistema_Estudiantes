using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class EstudianteService
    {
        private readonly IEstudianteRepository _repo;
        public EstudianteService(IEstudianteRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Estudiante>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Estudiante?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public async Task<Estudiante> CreateAsync(Estudiante estudiante)
        {
            Validar(estudiante);
            estudiante.id = 0;
            return await _repo.AddAsync(estudiante);
        }
        public async Task UpdateAsync(int id, Estudiante estudiante)
        {
            if (id != estudiante.id) throw new ArgumentException("Id no coincide");
            Validar(estudiante);
            await _repo.UpdateAsync(estudiante);
        }
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
        private static void Validar(Estudiante estudiante)
        {
            if (string.IsNullOrWhiteSpace(estudiante.cedula))
                throw new ArgumentException("Cédula es obligatoria");
            if (string.IsNullOrWhiteSpace(estudiante.primer_nombre))
                throw new ArgumentException("Primer nombre es obligatorio");
            if (string.IsNullOrWhiteSpace(estudiante.primer_apellido))
                throw new ArgumentException("Primer apellido es obligatorio");
            if (string.IsNullOrWhiteSpace(estudiante.ciudad))
                throw new ArgumentException("Ciuad es obligatoria");
            if (string.IsNullOrWhiteSpace(estudiante.segundo_apellido))
                throw new ArgumentException("Segundo apellido es obligatorio");
            if (estudiante.fecha_nacimiento == default)
                throw new ArgumentException("La fecha es obligatoria");
        }
    }
}
