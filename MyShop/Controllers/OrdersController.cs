using Entities;
using Microsoft.AspNetCore.Mvc;
using Reposetories;
using Servicess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderServicess servicess;
        public OrdersController(IOrderReposetories reposetory)
        {
            this.servicess = servicess;  
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
          List<  Order >order = await servicess.Get();
            if (order != null)
                return Ok(order);
            return NotFound();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order Order = await servicess.Get(id);
            if (Order != null)
                return Ok(Order);
            return NotFound();



        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            Order newOrder = await servicess.Post(order);
            if (newOrder != null)
             return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
            return BadRequest();
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
