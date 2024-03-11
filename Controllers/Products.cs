using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication6.Data;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ProductsAPIDbContext dbContext;

        public ProductsController(ProductsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dbContext.Products.ToListAsync());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();

        }
        //**Under Devlopment
        //[HttpGet]
        //public async Task<IActionResult> AddProduct()
        //{
        //    List<Category> categories = await dbContext.Categories.ToListAsync();
        //    ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
        //    return View(nameof(AddProductRequest));
        //}
        //**
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddProduct(AddProductRequest addProductRequest)
        {
            //**Under Developnment
            //List<Category> categories = await dbContext.Categories.ToListAsync();
            //**
            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = addProductRequest.Name,
                Description = addProductRequest.Description,
                Price = addProductRequest.Price

            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            //**Under Development
            //ViewData["CategoryId"] = new SelectList(dbContext.Set<Category>(), "Id", "Name", selectedValue: addProductRequest.CategoryId);
            //**
            return Ok(product);

        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductRequest updateProductRequest)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product != null)
            {
                product.Name = updateProductRequest.Name;
                product.Description = updateProductRequest.Description;
                product.Price = updateProductRequest.Price;


                await dbContext.SaveChangesAsync();
                return Ok(product);

            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            var product = await dbContext.Products.FindAsync(id);

            if (product != null)
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
                return Ok(product);
            }
            return NotFound();

        }


    }
}
