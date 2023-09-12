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
                    var product = _db.Products.Find(item.ProductId);
                    if(product != null)
                    {
                        if(product.Quantity >= item.Quantity)
                        {
                            items.Add(new OrderItem { ProductPrice = product.Price, Quantity = item.Quantity });
                            product.Quantity -= item.Quantity;
                        } 
                        else
                        {
                            return BadRequest("Không đủ số lượng để order");
                        }    
                    }
                    else
                    {
                        return BadRequest("Không tồn tại product");
                    } 
                        
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(string id)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
           try
            {
                _db.Orders.Include(o => o.Items).ToList();
                var oderRemove = _db.Orders.Find(id);
                if (oderRemove != null) { 
                    _db.Orders.Remove(oderRemove);
                    await _db.SaveChangesAsync();
                    return Ok(oderRemove);
                } else
            {
                    return BadRequest("Không tìm thấy order");   
            }

            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
