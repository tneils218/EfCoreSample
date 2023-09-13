using EfCoreSample.Controllers.Request;

namespace EfCoreSample.Services.DTOs
{
    public class OrderDTO
    {
        public List<OrderItemDTO> Items { get; private set; } = null!;
        private OrderDTO() {
            Items = new List<OrderItemDTO>();
        }
        public static OrderDTO CreateOrder(List<OrderItemRequest> items) 
        {
            var dto = new OrderDTO();
            foreach (var item in items)
            {
                var orderItemDto = OrderItemDTO.Create(item);
                dto.Items.Add(orderItemDto);
            }
            return dto;
        }
    }
}
