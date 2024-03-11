using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class ProductsAPIDbContext : IdentityDbContext<IdentityUser>
    {
        public ProductsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }        
        public DbSet<Category> Categories { get; set; }
        
    }
}
