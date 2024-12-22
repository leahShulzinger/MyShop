using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Servicess;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderServices services;
        IMapper mapper;
        public OrdersController(IOrderServices services, IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }

       
        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await services.GetById(id);
            if (order != null)
                return Ok(mapper.Map<Order, OrdersDTO>(order));
            return NotFound();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrdersDTO>> Post([FromBody] OrdersDTOPost order)
        {
            Order neworder = await services.Post(mapper.Map<OrdersDTOPost, Order>(order));
            if (order != null)
                return CreatedAtAction(nameof(Get), new {id= neworder.Id}, mapper.Map<Order,OrdersDTO>(neworder));
            return NotFound();
        }

    }
}
