using EfCoreSample.Controllers.Request;
using Org.BouncyCastle.Utilities;

namespace EfCoreSample.Services.DTOs
{
    public class ProductDTO
    {
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public ProductDTO(string name, decimal price, int quantity, string? description = "") 
        { 
            Name = name;
            Price = price;
            Quantity = quantity;
            Description = description;
        }
        public static ProductDTO Create(ProductRequest product)
        { 
            return new ProductDTO(product.Name, product.Price, product.Quantity, product.Description);
        }
    }
}
