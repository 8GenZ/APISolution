using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication6.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        //Navigational Properties
        //**Under Development
        //[JsonIgnore]
        //public virtual ICollection<Product>? Products { get; set; } = new HashSet<Product>();
        //**
    }
}
