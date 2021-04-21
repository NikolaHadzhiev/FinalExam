using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entitites
{
    [Table("Catalogues")]
    public class Catalogue
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Decription { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        public List<Song> Songs { get; set; }
        public List<Album> Albums { get; set; }

    }
}
