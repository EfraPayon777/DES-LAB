using System.ComponentModel.DataAnnotations;

namespace CC230286_DESAFIO_03.Entities.Dtos;

public class PedidoDto
{
    public int Id { get; set; }

    public DateTime FechaPedido { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "El clienteId es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El clienteId debe ser válido")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El productoId es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El productoId debe ser válido")]
    public int ProductoId { get; set; }

    public string? ClienteNombre { get; set; }

    public string? ProductoNombre { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Total { get; set; }
}
