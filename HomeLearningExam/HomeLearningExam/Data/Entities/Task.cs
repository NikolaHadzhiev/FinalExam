using Data.CustomExceptions;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Tasks")]
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        public Location Location { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public decimal Budget { get; set; }

        
        [Required]
        public TaskCategory TaskCategory { get; set; }

        public Status Status { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public ApplicationUser AsignedHousekeeper { get; set; }

        public string PhotoPath { get; set; }

        public DateTime SecondDueDate { get; set; }

    }
}
