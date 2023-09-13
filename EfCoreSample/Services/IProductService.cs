using EfCoreSample.Models;
using EfCoreSample.Services.DTOs;

namespace EfCoreSample.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(ProductDTO productDTO);
    }
}
