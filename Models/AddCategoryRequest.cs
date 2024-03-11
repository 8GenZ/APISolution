using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication6.Models
{
    public class AddCategoryRequest
    {
        [Required]
        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }     

    }
}
