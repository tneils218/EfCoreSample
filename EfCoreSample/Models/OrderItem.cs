using EfCoreSample.Services.DTOs;

namespace EfCoreSample.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; } = null!;

        public static OrderItem Create(decimal price, int quantity)
        {
            return new OrderItem
            {
                ProductPrice = price,
                Quantity = quantity
            };
        }
    }
}
