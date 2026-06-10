using UsuariosAPI.DTOs;
using UsuariosAPI.Models;
using UsuariosAPI.Repositories;

namespace UsuariosAPI.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Categoria>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Categoria?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Categoria> CreateAsync(CategoriaDto dto)
        {
            var categoria = new Categoria
            {
                Nombre = dto.Nombre
            };
            return await _repository.CreateAsync(categoria);
        }

        public async Task<Categoria?> UpdateAsync(int id, CategoriaDto dto)
        {
            var categoria = new Categoria
            {
                Nombre = dto.Nombre
            };
            return await _repository.UpdateAsync(id, categoria);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}