using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entitites
{
    [Table("Albums")]
    public class Album
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public Artist Author { get; set; }

        [Required]
        public DateTime DateOfRelease { get; set; }


    }
}
