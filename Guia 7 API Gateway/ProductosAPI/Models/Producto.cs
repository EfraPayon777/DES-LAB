
using System.ComponentModel.DataAnnotations;

namespace ProductosAPI.Models;

public class Producto
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    public string? Categoria { get; set; }

    public string? Descripcion { get; set; }
}
