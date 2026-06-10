using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.DTOs;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("api/proveedores")]
    [Authorize]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedorService _service;

        public ProveedoresController(IProveedorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proveedores = await _service.GetAllAsync();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var proveedor = await _service.GetByIdAsync(id);
            if (proveedor == null)
                return NotFound(new { mensaje = "Proveedor no encontrado." });
            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProveedorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var proveedor = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProveedorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var proveedor = await _service.UpdateAsync(id, dto);
            if (proveedor == null)
                return NotFound(new { mensaje = "Proveedor no encontrado." });
            return Ok(proveedor);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _service.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = "Proveedor no encontrado." });
            return Ok(new { mensaje = "Proveedor eliminado correctamente." });
        }
    }
}