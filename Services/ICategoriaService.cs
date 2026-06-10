using UsuariosAPI.DTOs;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task<Categoria> CreateAsync(CategoriaDto dto);
        Task<Categoria?> UpdateAsync(int id, CategoriaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}