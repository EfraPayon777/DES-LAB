using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CC230396_Desafio01.Entities.Dtos
{
    public class LibroDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio.")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de publicación es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Autor.")]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una Categoría.")]
        public int CategoriaId { get; set; }
    }
}