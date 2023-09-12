using EfCoreSample.Db;
using EfCoreSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EfCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(CreateProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var productToRemove = _db.Products.Find(id);

                if (productToRemove == null)
                {
                    return NotFound("Product not found.");
                }

                _db.Products.Remove(productToRemove);
                _db.SaveChanges();

                return Ok(productToRemove);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                var findProduct = _db.Products.Find(id);

                if (findProduct == null)
                {
                    return NotFound("Product not found.");
                }
                findProduct.Price = updatedProduct.Price;
                findProduct.Quantity = updatedProduct.Quantity;
                findProduct.Description = updatedProduct.Description;
                findProduct.Name = updatedProduct.Name;
                _db.SaveChanges();
                return Ok(findProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
