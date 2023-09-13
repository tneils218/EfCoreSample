using EfCoreSample.Db;
using EfCoreSample.Models;
using EfCoreSample.Services.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSample.Services.Impls
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;

        public OrderService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Order> CreateOrder(OrderDTO orderDto)
        {
            var order = new Order();
            using var transaction = _db.Database.BeginTransaction();
            foreach (var item in orderDto.Items)
            {
                var product = await _db.Products.FindAsync(item.ProductId);
                if (product != null && product.Quantity >= item.Quantity)
                {
                    order.Items.Add(OrderItem.Create(product.Price, item.Quantity));
                    product.Quantity -= item.Quantity;
                }
            }
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            transaction.Commit();
            return order;
        }

        public async Task<List<Order>> GetAll(string? id = "")
        {
            IQueryable<Order> query = _db.Orders.Include(o => o.Items);
            if (!string.IsNullOrEmpty(id))
            {   
                query = query.Where(o => o.Id == id);
            }

            var orders = await query.ToListAsync();
            return orders;
        }
    }


}
