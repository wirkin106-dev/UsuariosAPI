using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.DTOs
{
    public class CategoriaDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
    }
}