namespace EfCoreSample.Models
{
    public class Order
    {
        public string Id { get; set; }  
        public DateTime CreatedAt { get; set; }

        public List<OrderItem> Items { get; set; } = null!;

        public Order() { }
    
        public Order(List<OrderItem> items)
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
            Items = items;

        }
    }
}
