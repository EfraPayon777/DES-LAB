using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CC230396_Desafio01.Entities.Dtos
{
    public class AutorDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido del autor es obligatorio.")]
        [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres.")]
        public string Apellido { get; set; } = string.Empty;
    }
}
