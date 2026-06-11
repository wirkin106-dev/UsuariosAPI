using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.DTOs
{
    public class ProductoDto
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int IdProveedor { get; set; }

        [Required]
        public int IdCategoria { get; set; }
    }
}