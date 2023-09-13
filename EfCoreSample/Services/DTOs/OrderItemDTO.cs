using EfCoreSample.Controllers.Request;
using System.ComponentModel.DataAnnotations;

namespace EfCoreSample.Services.DTOs
{
    public class OrderItemDTO
    {
        public int Quantity { get; private set; }
        public int ProductId { get; private set; }

        public static OrderItemDTO Create(OrderItemRequest item)
        {
            var dto = new OrderItemDTO
            {
                Quantity = item.Quantity,
                ProductId = item.ProductId
            };
            return dto;
        }
    }
}
