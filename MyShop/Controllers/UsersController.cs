using Servicess;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserServicess servicess ;

        public UsersController(IUserServicess servicess)
        {
            this.servicess = servicess;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "shabat", "shalom" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult<User>> Get(int id)
        {
             User user =await servicess.Get(id);
            if(user!=null)
             return Ok(user);
             return NotFound(); 



        }

        // POST api/<UsersController>
        [HttpPost]

        public async Task< ActionResult<User>> Post([FromBody] User user)
        {
           User newUser=await servicess.Post(user);
            if(newUser!=null)
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
            return BadRequest();

        }
        [HttpPost("checkPassword")]

        public async Task<ActionResult<int>> CheckPassword([FromBody] string password)
        {
           int levelPassword= servicess.CheckPassword(password);
           
                return Ok(levelPassword);
          
            

        }

        [HttpPost("login")]
       
        public async Task< ActionResult> Login([FromQuery] string email, [FromQuery] string password)
        {

           
                User user= await servicess.Login(email, password);
                if(user!=null)
                        return Ok(user);
                  
            return NoContent();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task< ActionResult<User>> Put(int id, [FromBody] User userToUpdate)
        {

            User user = await servicess.Put(id, userToUpdate);
            if(user!=null)
                return Ok(userToUpdate);
           return BadRequest();


        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
       
    }
}
