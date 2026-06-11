using Microsoft.EntityFrameworkCore;
using UsuariosAPI.Data;
using UsuariosAPI.Models;

namespace UsuariosAPI.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Producto> CreateAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<Producto?> UpdateAsync(int id, Producto producto)
        {
            var existente = await _context.Productos.FindAsync(id);
            if (existente == null) return null;

            existente.Nombre = producto.Nombre;
            existente.Precio = producto.Precio;
            existente.Stock = producto.Stock;
            existente.IdProveedor = producto.IdProveedor;
            existente.IdCategoria = producto.IdCategoria;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return false;

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Producto>> GetByCategoriaAsync(int idCategoria)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .Where(p => p.IdCategoria == idCategoria)
                .ToListAsync();
        }

        public async Task<IEnumerable<Producto>> GetByProveedorAsync(int idProveedor)
        {
            return await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .Where(p => p.IdProveedor == idProveedor)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Productos.CountAsync();
        }

        public async Task<object> GetEstadisticasAsync()
        {
            var productos = await _context.Productos.ToListAsync();

            if (!productos.Any())
                return new { mensaje = "No hay productos registrados." };

            return new
            {
                precioMasAlto = productos.MaxBy(p => p.Precio),
                precioMasBajo = productos.MinBy(p => p.Precio),
                sumaTotalPrecios = productos.Sum(p => p.Precio),
                precioPromedio = productos.Average(p => p.Precio)
            };
        }
    }
}