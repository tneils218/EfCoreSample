using EfCoreSample.Models;
using EfCoreSample.Services.DTOs;

namespace EfCoreSample.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderDTO orderDto);
        Task<List<Order>> GetAll(string? id = "");
    }
}
