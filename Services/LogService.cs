using System.Text.Json;
using UsuariosAPI.DTOs;

namespace UsuariosAPI.Services
{
    public class LogService : ILogService
    {
        private readonly string _logPath;

        public LogService()
        {
            _logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usuarios_log.json");
        }

        public async Task RegistrarAsync(LogEntryDto entry)
        {
            try
            {
                var logs = await ObtenerLogsAsync() as List<LogEntryDto>
                           ?? new List<LogEntryDto>();

                var listaLogs = logs.ToList();
                listaLogs.Add(entry);

                var json = JsonSerializer.Serialize(listaLogs, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                await File.WriteAllTextAsync(_logPath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir log: {ex.Message}");
            }
        }

        public async Task<IEnumerable<LogEntryDto>> ObtenerLogsAsync()
        {
            try
            {
                if (!File.Exists(_logPath))
                    return new List<LogEntryDto>();

                var json = await File.ReadAllTextAsync(_logPath);

                if (string.IsNullOrWhiteSpace(json))
                    return new List<LogEntryDto>();

                return JsonSerializer.Deserialize<List<LogEntryDto>>(json)
                       ?? new List<LogEntryDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer log: {ex.Message}");
                return new List<LogEntryDto>();
            }
        }
    }
}