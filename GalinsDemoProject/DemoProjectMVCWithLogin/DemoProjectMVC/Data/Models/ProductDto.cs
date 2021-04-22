using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
