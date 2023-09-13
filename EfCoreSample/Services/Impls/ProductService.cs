using EfCoreSample.Controllers.Request;
using EfCoreSample.Db;
using EfCoreSample.Models;
using EfCoreSample.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using System.Xml.Linq;

namespace EfCoreSample.Services.Impls
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Product> CreateProduct(ProductDTO productDTO)
        {
            var product = new Product(productDTO.Name, productDTO.Price, productDTO.Quantity, productDTO.Description);
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
    }

        public async Task<List<Product>> GetAll(string? name = "")
        {
            IQueryable<Product> query = _db.Products;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(o => o.Name == name);
            }

            var products = await query.ToListAsync();
            return products;
        }
    }
}
