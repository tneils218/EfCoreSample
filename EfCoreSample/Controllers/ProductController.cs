using EfCoreSample.Controllers.Request;
using EfCoreSample.Db;
using EfCoreSample.Models;
using EfCoreSample.Services;
using EfCoreSample.Services.DTOs;
using EfCoreSample.Services.Impls;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Threading.Tasks;

namespace EfCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            try
            {
                var productDto = ProductDTO.Create(request);
                var product = await _productService.CreateProduct(productDto);

                return CreatedAtAction(nameof(CreateProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpDelete("{id}")]
        //public IActionResult DeleteProduct(int id)
        //{
        //    try
        //    {
        //        var productToRemove = _db.Products.Find(id);

        //        if (productToRemove == null)
        //        {
        //            return NotFound("Product not found.");
        //        }

        //        _db.Products.Remove(productToRemove);
        //        _db.SaveChanges();

        //        return Ok(productToRemove);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}
        //[HttpPut("{id}")]
        //public IActionResult UpdateProduct(int id, [FromBody] Product updatedProduct)
        //{
        //    try
        //    {
        //        var findProduct = _db.Products.Find(id);

        //        if (findProduct == null)
        //        {
        //            return NotFound("Product not found.");
        //        }
        //        findProduct.Price = updatedProduct.Price;
        //        findProduct.Quantity = updatedProduct.Quantity;
        //        findProduct.Description = updatedProduct.Description;
        //        findProduct.Name = updatedProduct.Name;
        //        _db.SaveChanges();
        //        return Ok(findProduct);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"An error occurred: {ex.Message}");
        //    }
        //}
    }
}
