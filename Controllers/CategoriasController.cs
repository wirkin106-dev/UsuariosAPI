using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.DTOs;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    [Authorize]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _service.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _service.GetByIdAsync(id);
            if (categoria == null)
                return NotFound(new { mensaje = "Categoría no encontrada." });
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var categoria = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var categoria = await _service.UpdateAsync(id, dto);
            if (categoria == null)
                return NotFound(new { mensaje = "Categoría no encontrada." });
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _service.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = "Categoría no encontrada." });
            return Ok(new { mensaje = "Categoría eliminada correctamente." });
        }
    }
}