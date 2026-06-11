using UsuariosAPI.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto> CreateAsync(ProductoDto dto);
        Task<Producto?> UpdateAsync(int id, ProductoDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Producto>> GetByCategoriaAsync(int idCategoria);
        Task<IEnumerable<Producto>> GetByProveedorAsync(int idProveedor);
        Task<int> GetTotalCountAsync();
        Task<object> GetEstadisticasAsync();
    }
}