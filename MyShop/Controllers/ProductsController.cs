using Entities;
using Microsoft.AspNetCore.Mvc;
using Servicess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductServicess servicess;


           public ProductsController(IProductServicess servicess)
        {
            this.servicess = servicess;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task <ActionResult<List<Product>>> Get()
        { var products= await servicess.Get();
            if (products != null)
                return Ok(products);
            return NotFound();
           
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            Product product = await servicess.GetById(id);
            if (product != null)
                return Ok(product);
            return NotFound();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
