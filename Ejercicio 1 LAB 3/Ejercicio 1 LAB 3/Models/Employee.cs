using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio_1_LAB_3.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        // Initialize collection to avoid model-binding treating it as required when using nullable reference types
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
