using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entitites
{
    [Table("Artists")]
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public byte[] ProfilePicture { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

    }
}
