using System.ComponentModel.DataAnnotations;

namespace EfCoreSample.Controllers.Request
{
    public class OrderItemRequest
    {
        [Range(0, 100)]
        public int Quantity { get; set; }
        [Range(0, int.MaxValue)]
        public int ProductId { get; set; }
    }
}
