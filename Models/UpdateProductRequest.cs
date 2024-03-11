using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class UpdateProductRequest
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }
    }
}
