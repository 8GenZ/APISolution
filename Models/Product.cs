using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Product
    {
        //primary key
        public Guid Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }
        //**Under Development
        //public virtual Category? Catgeory { get; set; }
    }
}
