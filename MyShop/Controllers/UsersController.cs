using Servicess;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Entities;
using DTO;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUseServices userservicess;
        IMapper mapper;
        public UsersController(IUseServices userservicess,IMapper mapper)
        {
            this.mapper = mapper;
            this.userservicess = userservicess;
        }
        // GET: api/<UsersController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{

        //}

        // GET api/<UsersController>/5

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTOGet>> Get(int id)
        {
            User user = await userservicess.Get(id);
                    if (user!=null)
                        return Ok(mapper.Map<User,UserDTOGet>(user));          
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]

        public async Task<ActionResult<UserDTOGet>> Post([FromBody] UserDTO user)
        {  
            User newuser= await userservicess.Post(mapper.Map<UserDTO,User>(user));
            
            if (newuser!=null)
            return CreatedAtAction(nameof(Get), new {id= newuser.Id}, mapper.Map<User,UserDTOGet>(newuser)); 
            return BadRequest();
        }

        [HttpPost("login")]
       
        public async Task<ActionResult<UserDTOGet>> Login([FromQuery] string email, [FromQuery] string password)
        {

            User user = await userservicess.Login(email,password);
            if(user!=null)
            return Ok(mapper.Map<User,UserDTOGet>(user));
            return NoContent();

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTOGet>> Put(int id, [FromBody] UserDTO userToUpdate)
        {
            User user = await userservicess.Put(id,mapper.Map<UserDTO,User>(userToUpdate));
            if (user != null)
                return Ok(mapper.Map<User, UserDTOGet>(user));            
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
