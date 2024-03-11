using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ProductsAPIDbContext dbContext;

        public CategoriesController(ProductsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await dbContext.Categories.ToListAsync());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetCategory([FromRoute] Guid id)
        {
            return Ok(await dbContext.Categories.FindAsync(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(AddCategoryRequest addCategoryRequest)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                CategoryName = addCategoryRequest.CategoryName,
                CategoryDescription = addCategoryRequest.CategoryDescription,
            };
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();
            return Ok(category);

        }


    }
}
