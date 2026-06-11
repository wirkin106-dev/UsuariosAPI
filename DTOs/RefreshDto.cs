using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.DTOs
{
    public class RefreshDto
    {
        [Required]
        public string Token { get; set; } = string.Empty;
    }
}