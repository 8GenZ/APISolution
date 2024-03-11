using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication6.Models
{
    public class AddProductRequest
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int Price { get; set; }
        //**Under Development
        //public Guid CategoryId { get; set; }

        //[JsonIgnore]
        //public virtual Category? Category { get; set; }
        //****
    }
}
