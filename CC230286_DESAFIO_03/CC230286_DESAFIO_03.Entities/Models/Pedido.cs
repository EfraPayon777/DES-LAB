using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CC230286_DESAFIO_03.Entities.Models;

public class Pedido
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "La fecha del pedido es obligatoria")]
    public DateTime FechaPedido { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El cliente es obligatorio")]
    public int ClienteId { get; set; }

    [ForeignKey(nameof(ClienteId))]
    public Cliente? Cliente { get; set; }

    [Required(ErrorMessage = "El producto es obligatorio")]
    public int ProductoId { get; set; }

    [ForeignKey(nameof(ProductoId))]
    public Producto? Producto { get; set; }
}
