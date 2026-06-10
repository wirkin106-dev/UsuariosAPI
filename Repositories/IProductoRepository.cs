using UsuariosAPI.Models;

namespace UsuariosAPI.Repositories
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto?> GetByIdAsync(int id);
        Task<Producto> CreateAsync(Producto producto);
        Task<Producto?> UpdateAsync(int id, Producto producto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Producto>> GetByCategoriaAsync(int idCategoria);
        Task<IEnumerable<Producto>> GetByProveedorAsync(int idProveedor);
        Task<int> GetTotalCountAsync();
        Task<object> GetEstadisticasAsync();
    }
}