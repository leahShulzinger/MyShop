using Entities;
using Microsoft.AspNetCore.Mvc;
using Servicess;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryServicess servicess;
        public CategoriesController(ICategoryServicess servicess)
        {
            this.servicess = servicess;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task <ActionResult<List<Category>>> Get()
        {
            List<Category> categories = await servicess.Get();
            if (categories != null)
                return Ok(categories);
            return BadRequest();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
           Category category = await servicess.GetById(id);
            return category;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
