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
    public class ProductsController : ControllerBase
    {
        IProductServicess servicess;
        IMapper _mapper;

        public ProductsController(IProductServicess servicess, IMapper mapper)
        {
            this.servicess = servicess;
            _mapper = mapper;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] string? desc, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> products = await servicess.Get(desc,minPrice,maxPrice,categoryIds);
            if (products != null)
                return Ok(_mapper.Map<List<Product>, List<ProductDTO>>(products));
            return NotFound();

        }


    }
}
