using System;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio_1_LAB_3.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        // Navigation properties optional for model binding; use Ids for creating assignments
        public Employee? Employee { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project? Project { get; set; }

        [DataType(DataType.Date)]
        public DateTime AssignedDate { get; set; }

        [StringLength(200)]
        public string Role { get; set; }
    }
}
