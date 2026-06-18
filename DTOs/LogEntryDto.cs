namespace UsuariosAPI.DTOs
{
    public class LogEntryDto
    {
        public DateTime Fecha { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
    }
}