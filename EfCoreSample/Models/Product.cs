namespace EfCoreSample.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Product() { }
        public Product (string  name, decimal price, int quantity, string? description = "")
        {
            Name = name; Price = price; Quantity = quantity; Description = description;
            UpdatedAt = DateTime.Now;
        }

        public int IncreaseQuantity(int desiredQuantity)
        {
            if (desiredQuantity <= 0) throw new Exception("Số lượng cân tăng không được  bé hơn 0");
            Quantity += desiredQuantity;
            return desiredQuantity;
        }

        public int DecreaseQuantity(int desiredQuantity)
        {
            if (desiredQuantity <= 0) throw new Exception("Số lượng cân giảm không được  bé hơn 0");
            if (Quantity < desiredQuantity) throw new Exception("Số lượng cần giảm không hợp lệ");
            Quantity -= desiredQuantity;
            return desiredQuantity;
        }
    }
}
