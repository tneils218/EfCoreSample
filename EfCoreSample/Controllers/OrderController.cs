using EfCoreSample.Controllers.Request;
using EfCoreSample.Db;
using EfCoreSample.Models;
using EfCoreSample.Services;
using EfCoreSample.Services.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAll();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            try
            {
                var orderDto = OrderDTO.Create(request.Items);
                var order = await _orderService.CreateOrder(orderDto);
                return CreatedAtAction(nameof(CreateOrder), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder(string id)
        //{
        //    if (!ModelState.IsValid) return ValidationProblem(ModelState);
        //   try
        //    { 
        //        var oderRemove = _db.Orders.Include(o => o.Items).FirstOrDefault(o => o.Id == id);
        //        if (oderRemove != null) { 
        //            _db.Orders.Remove(oderRemove);
        //            await _db.SaveChangesAsync();
        //            return Ok(oderRemove);
        //        } else
        //    {
        //            return BadRequest("Không tìm thấy order");   
        //    }

        //    } catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
    }
}
