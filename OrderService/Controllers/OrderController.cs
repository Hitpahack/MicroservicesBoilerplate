using Microsoft.AspNetCore.Mvc;
using OrderService.DTOs;
using OrderService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders =_orderService.GetAllOrders();
            return Ok(orders);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);   
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null) {
                return BadRequest("Invalid Order Data");
            }
            var createOrder = _orderService.CreateOrder(orderDto);
            return CreatedAtAction(nameof(GetOrder),new { id = createOrder.Id },createOrder);
        }

        //PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderDto orderDto)
        {
            if(id <=0 )
            {
                return BadRequest("Invalid Order ID.");
            }
            if (orderDto == null)
            {
                return BadRequest("Order data is required.");
            }
            var updateOrder = _orderService.UpdateOrder(id, orderDto);
            if(updateOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }
            return Ok(updateOrder);

        }

        //DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Order ID.");
            }

            var deletedOrder = _orderService.DeleteOrder(id);

            if (deletedOrder == null)
            {
                return NotFound($"Order with ID {id} not found.");
            }

            return NoContent(); // 204 No Content (successful deletion)
        }
    }
}
