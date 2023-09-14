using EfCoreSample.Services.DTOs;

namespace EfCoreSample.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; } = null!;
        public int ProductId { get; set; }

        public static OrderItem Create(decimal price, int quantity, int productId)
        {
            return new OrderItem
            {
                ProductPrice = price,
                Quantity = quantity,
                ProductId = productId
            };
        }
    }
}
