using EfCoreSample.Db;
using EfCoreSample.Models;
using EfCoreSample.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

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
                if (product != null)
                {
                    product.DecreaseQuantity(item.Quantity);
                    order.Items.Add(OrderItem.Create(product.Price, item.Quantity, item.ProductId));
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

        public async Task<Order> UpdateOrder(string Id, OrderDTO orderDto)
        {
            var order = await _db.Orders.Where(o => o.Id == Id).Include(o => o.Items).FirstOrDefaultAsync();

            if (order == null)
            {
                return null; 
            }

            using var transaction = _db.Database.BeginTransaction();

            foreach (var itemDto in orderDto.Items)
            {
                var existingItem = order.Items.FirstOrDefault(item => item.ProductId == itemDto.ProductId);
                var product = await _db.Products.FindAsync(itemDto.ProductId);

                if (existingItem != null && product != null)
                { 
                    if(product.Quantity >= itemDto.Quantity)
                    {
                        product.DecreaseQuantity(itemDto.Quantity);
                        existingItem.Quantity = existingItem.Quantity + itemDto.Quantity;

                    }
                }
                else
                {
                   if(product != null)
                    { 
                    
                    order.Items.Add(OrderItem.Create(product.Price, itemDto.Quantity, itemDto.ProductId));
                    }
                    


                }
            }

       
            await _db.SaveChangesAsync();
            transaction.Commit();

            return order;
        }
    }


}
