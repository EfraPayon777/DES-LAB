using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC230286_DESAFIO_03.Entities.Models;

public class Producto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio")]
    [StringLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio")]
    [Range(0.01, 1000000.00, ErrorMessage = "El precio debe ser mayor a 0")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El stock es obligatorio")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
    public int Stock { get; set; }

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
