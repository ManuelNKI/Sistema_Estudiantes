using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Sistema_Estudiantes.Controllers
{
    [Route("api/estudiante")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteService _service;

        public EstudianteController(EstudianteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estudiante>>> GetAll()
            => await _service.GetAllAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetById(int id)
        {
            var p = await _service.GetByIdAsync(id);
            return p == null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public async Task<ActionResult<Estudiante>> Create(Estudiante estudiante)
        {
            try
            {
                var created = await _service.CreateAsync(estudiante);
                return CreatedAtAction(nameof(GetById), new { id = created.id }, created);
            }
            catch (Exception ex)
            {
                // Atrapa el error de la base de datos o las validaciones del servicio
                // y devuelve un error 400 (Bad Request) con el texto para Flutter
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Estudiante estudiante)
        {
            try
            {
                await _service.UpdateAsync(id, estudiante);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Hace exactamente lo mismo para la actualización, 
                // por si intentan cambiar la cédula a una que ya existe
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
