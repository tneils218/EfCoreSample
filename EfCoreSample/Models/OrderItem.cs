namespace EfCoreSample.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string OrderId { get; set; } = null!;
    }
}
