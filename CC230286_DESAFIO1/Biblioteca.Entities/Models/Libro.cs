using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CC230396_Desafio01.Entities.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }
    }
}
