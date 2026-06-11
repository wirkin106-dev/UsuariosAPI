using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        public int IdProveedor { get; set; }
        public Proveedor Proveedor { get; set; } = null!;

        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; } = null!;
    }
}