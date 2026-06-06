using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        public DateTime FechaDeNacimiento { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(256)]
        public string Password { get; set; } = string.Empty;
    }
}