using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entitites
{
    [Table("Songs")]
    public class Song
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public TimeSpan Lenght { get; set; }
        [Required]
        public Artist Author { get; set; }

        public Album Album { get; set; }
    }
}
