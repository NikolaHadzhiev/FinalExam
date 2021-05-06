using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Adress { get; set; }

    }
}
