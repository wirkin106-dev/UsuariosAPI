using UsuariosAPI.DTOs;
using UsuariosAPI.Models;
using UsuariosAPI.Repositories;

namespace UsuariosAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Producto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Producto> CreateAsync(ProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock,
                IdProveedor = dto.IdProveedor,
                IdCategoria = dto.IdCategoria
            };
            return await _repository.CreateAsync(producto);
        }

        public async Task<Producto?> UpdateAsync(int id, ProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock,
                IdProveedor = dto.IdProveedor,
                IdCategoria = dto.IdCategoria
            };
            return await _repository.UpdateAsync(id, producto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Producto>> GetByCategoriaAsync(int idCategoria)
        {
            return await _repository.GetByCategoriaAsync(idCategoria);
        }

        public async Task<IEnumerable<Producto>> GetByProveedorAsync(int idProveedor)
        {
            return await _repository.GetByProveedorAsync(idProveedor);
        }

        public async Task<int> GetTotalCountAsync()
        {
            return await _repository.GetTotalCountAsync();
        }

        public async Task<object> GetEstadisticasAsync()
        {
            return await _repository.GetEstadisticasAsync();
        }
    }
}