using UsuariosAPI.DTOs;

namespace UsuariosAPI.Services
{
    public interface ILogService
    {
        Task RegistrarAsync(LogEntryDto entry);
        Task<IEnumerable<LogEntryDto>> ObtenerLogsAsync();
    }
}