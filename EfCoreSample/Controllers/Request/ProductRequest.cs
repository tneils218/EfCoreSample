using System.ComponentModel.DataAnnotations;

namespace EfCoreSample.Controllers.Request
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be at most 100 characters.")]
        public string Name { get;  set; } = null!;
        [StringLength(int.MaxValue)]
        public string? Description { get; set; } = "";
        [Range(0, int.MaxValue)]
        public decimal Price { get;  set; }
        [Range(0, 100)]
        public int Quantity { get;  set; }

    }
}
