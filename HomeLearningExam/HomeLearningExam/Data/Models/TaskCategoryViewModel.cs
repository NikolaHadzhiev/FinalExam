using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TaskCategoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
