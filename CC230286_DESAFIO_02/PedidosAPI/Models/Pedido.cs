using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PedidosAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }


        public int ClienteId { get; set; }
    }
}