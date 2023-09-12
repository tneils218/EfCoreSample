using EfCoreSample.Db;
using EfCoreSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var orders = _db.Orders.ToList();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
                return CreatedAtAction(nameof(CreateProduct), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
