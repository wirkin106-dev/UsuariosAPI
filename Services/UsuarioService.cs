using System.Security.Cryptography;
using System.Text;
using UsuariosAPI.DTOs;
using UsuariosAPI.Models;
using UsuariosAPI.Repositories;

namespace UsuariosAPI.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogService _logService;

        public UsuarioService(IUsuarioRepository repository, ILogService logService)
        {
            _repository = repository;
            _logService = logService;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Usuario> CreateAsync(UsuarioDto dto)
        {
            var existente = await _repository.GetByCorreoAsync(dto.Correo);
            if (existente != null)
                throw new InvalidOperationException("El correo electrónico ya está en uso.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                FechaDeNacimiento = dto.FechaDeNacimiento,
                Password = HashPassword(dto.Password)
            };

            var creado = await _repository.CreateAsync(usuario);

            await _logService.RegistrarAsync(new LogEntryDto
            {
                Fecha = DateTime.UtcNow,
                Accion = "REGISTRO",
                Detalle = $"Usuario creado: {creado.Nombre} | Correo: {creado.Correo} | Id: {creado.Id}"
            });

            return creado;
        }

        public async Task<Usuario?> UpdateAsync(int id, UsuarioDto dto)
        {
            var existente = await _repository.GetByCorreoAsync(dto.Correo);
            if (existente != null && existente.Id != id)
                throw new InvalidOperationException("El correo electrónico ya está en uso.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                FechaDeNacimiento = dto.FechaDeNacimiento,
                Password = HashPassword(dto.Password)
            };

            return await _repository.UpdateAsync(id, usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}