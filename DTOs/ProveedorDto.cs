using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.DTOs
{
    public class ProveedorDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        public string Contacto { get; set; } = string.Empty;
    }
}