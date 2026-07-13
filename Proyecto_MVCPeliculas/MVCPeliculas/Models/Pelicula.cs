using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPeliculas.Models
{

    public class Pelicula
    {
        public int Id { get; set; }

        [StringLength(250)]
        [Required]
        public string Titulo { get; set; }

        public DateTime FechaLanzamiento { get; set; }

        [Column(TypeName = "money")]
        [Required]
        public decimal Precio { get; set; }

        [StringLength(15)]
        [Required]
        public string Director { get; set; }

        [Required]
        public int GeneroId { get; set; } // <- Llave foranea 

        public Genero Genero { get; set; } // <- Propiedad de navegacion 
    }
}
