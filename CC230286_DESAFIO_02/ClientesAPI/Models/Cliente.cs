using System.ComponentModel.DataAnnotations;

namespace ClientesAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        public string Apellido { get; set; } = string.Empty;

        public string? Email { get; set; }
        public string? Telefono { get; set; }
    }
}