using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.DTOs
{
    public class UsuarioDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public DateTime FechaDeNacimiento { get; set; }
    }
}