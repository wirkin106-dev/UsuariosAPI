using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.DTOs;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _service.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _service.GetByIdAsync(id);
            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado." });
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var producto = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var producto = await _service.UpdateAsync(id, dto);
            if (producto == null)
                return NotFound(new { mensaje = "Producto no encontrado." });
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _service.DeleteAsync(id);
            if (!resultado)
                return NotFound(new { mensaje = "Producto no encontrado." });
            return Ok(new { mensaje = "Producto eliminado correctamente." });
        }

        [HttpGet("estadisticas")]
        public async Task<IActionResult> GetEstadisticas()
        {
            var estadisticas = await _service.GetEstadisticasAsync();
            return Ok(estadisticas);
        }

        [HttpGet("categoria/{idCategoria}")]
        public async Task<IActionResult> GetByCategoria(int idCategoria)
        {
            var productos = await _service.GetByCategoriaAsync(idCategoria);
            return Ok(productos);
        }

        [HttpGet("proveedor/{idProveedor}")]
        public async Task<IActionResult> GetByProveedor(int idProveedor)
        {
            var productos = await _service.GetByProveedorAsync(idProveedor);
            return Ok(productos);
        }

        [HttpGet("total")]
        public async Task<IActionResult> GetTotal()
        {
            var total = await _service.GetTotalCountAsync();
            return Ok(new { totalProductos = total });
        }
    }
}