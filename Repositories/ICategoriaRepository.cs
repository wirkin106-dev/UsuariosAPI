using UsuariosAPI.Models;

namespace UsuariosAPI.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task<Categoria> CreateAsync(Categoria categoria);
        Task<Categoria?> UpdateAsync(int id, Categoria categoria);
        Task<bool> DeleteAsync(int id);
    }
}