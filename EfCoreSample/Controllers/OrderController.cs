using EfCoreSample.Controllers.Request;
using EfCoreSample.Db;
using EfCoreSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _db;

        public OrderController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _db.Orders.Include(o => o.Items).ToList();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var items = new List<OrderItem>();
                foreach (var item in request.Items)
                {
                    items.Add(new OrderItem { ProductPrice = item.ProductPrice, Quantity = item.Quantity });
                }
                var order = new Order(items);
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
