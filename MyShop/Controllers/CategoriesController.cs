using AutoMapper;
using DTO;
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
        IMapper _mapper;
        public CategoriesController(ICategoryServicess servicess, IMapper mapper)
        {
            this.servicess = servicess;
            _mapper = mapper;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> Get()
        {
            List<Category> categories = await servicess.Get();
            if (categories != null)
                return Ok(_mapper.Map<List<Category>, List<CategoryDTO>>(categories));
            return BadRequest();
        }


    }
}
