using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(54)]
        public string Name { get; set; }

        [Required]
        [Column(Order = 1, TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string sthNew { get; set; }
    }
}
