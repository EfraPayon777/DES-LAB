using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPeliculas.Models
{

    public class Pelicula
    {
        public int Id { get; set; }

        [StringLength(250, MinimumLength = 3, ErrorMessage = "Debe escribir al menos 3 letras")]
        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Fecha de lanzamiento")]
        [DataType(DataType.Date)]
        public DateTime FechaLanzamiento { get; set; }

        [Column(TypeName = "money")]
        [Required]
        [Range(1, 100, ErrorMessage = "El precio debe estar entre 1 y 100")]
        public decimal Precio { get; set; }

        [StringLength(15)]
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$", ErrorMessage = "El nombre del director debe comenzar con mayúscula y solo puede contener letras, espacios, comillas y guiones.")]
        public string Director { get; set; }

        [Required]
        public int GeneroId { get; set; } //Llave foránea

        [Display(Name = "Género")]
        //? -> propiedad no requerida
        public Genero? Genero { get; set; } // Propiedad de navegación
    }
}
