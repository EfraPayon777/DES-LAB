using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CC230396_Desafio01.Entities.Models
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
    }
}
