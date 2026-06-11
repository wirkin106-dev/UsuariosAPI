using UsuariosAPI.DTOs;
using UsuariosAPI.Models;
using UsuariosAPI.Repositories;

namespace UsuariosAPI.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _repository;

        public ProveedorService(IProveedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Proveedor>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Proveedor> CreateAsync(ProveedorDto dto)
        {
            var proveedor = new Proveedor
            {
                Nombre = dto.Nombre,
                Contacto = dto.Contacto
            };
            return await _repository.CreateAsync(proveedor);
        }

        public async Task<Proveedor?> UpdateAsync(int id, ProveedorDto dto)
        {
            var proveedor = new Proveedor
            {
                Nombre = dto.Nombre,
                Contacto = dto.Contacto
            };
            return await _repository.UpdateAsync(id, proveedor);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}