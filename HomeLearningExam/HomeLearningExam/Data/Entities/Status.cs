using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Statuses")]
    public class Status
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TaskStatus { get; set; }
    }
}
