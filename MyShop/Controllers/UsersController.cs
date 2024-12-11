using Servicess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUseServices userservicess;
        public UsersController(IUseServices userservicess)
        {
            this.userservicess = userservicess;
        }
        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{

        //}

        // GET api/<UsersController>/5

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User user = await userservicess.Get(id);
                    if (user!=null)
                        return Ok(user);          
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]

        public async Task<IActionResult> Post([FromBody] User user)
        {  
            User newuser= await userservicess.Post(user);
            
            if (newuser!=null)
            return CreatedAtAction(nameof(Get), new {id=user.Id},user); 
            return BadRequest();
        }

        [HttpPost("login")]
       
        public async Task<ActionResult<User>> Login([FromQuery] string email, [FromQuery] string password)
        {

            User user = await userservicess.Login(email,password);
            if(user!=null)
            return Ok();
            return NoContent();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User userToUpdate)
        {
            User user = await userservicess.Put(id, userToUpdate);
            if (user != null)
                return Ok(userToUpdate);            
            return BadRequest();
        }

        
        [HttpPost("chakepassword")]
        public ActionResult<int> Chakepassword([FromBody] string password)
        {

            int levelPassword = userservicess.Chakepassword(password);
            return Ok(levelPassword);

        }

    }
}
