using UsuariosAPI.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public interface IProveedorService
    {
        Task<IEnumerable<Proveedor>> GetAllAsync();
        Task<Proveedor?> GetByIdAsync(int id);
        Task<Proveedor> CreateAsync(ProveedorDto dto);
        Task<Proveedor?> UpdateAsync(int id, ProveedorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}