using UsuariosAPI.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario> CreateAsync(UsuarioDto dto);
        Task<Usuario?> UpdateAsync(int id, UsuarioDto dto);
        Task<bool> DeleteAsync(int id);
    }
}