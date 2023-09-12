using System.ComponentModel.DataAnnotations;

namespace EfCoreSample.Controllers.Request
{
    public class OrderRequest : IValidatableObject
    {
        public List<OrderItemRequest> Items { get; set; } = null!;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Items.Count == 0) yield return new ValidationResult("Số lượng item phải lớn hơn 0");

        }
    }
}
