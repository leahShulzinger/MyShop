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
    public class ProdectsController : ControllerBase
    {
        IProductServices services;
        IMapper mapper;
        public ProdectsController(IProductServices services,IMapper mapper)
        {
            this.services = services;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get([FromQuery] string? desc, [FromQuery] float? minPrice, [FromQuery] float? maxPrice, [FromQuery] int?[] categoryIds)
        {
            List<Product> product = await services.Get(desc, minPrice, maxPrice, categoryIds);

            if (product != null)
                return Ok(mapper.Map<List<Product>,List<ProductDTO>>(product));
            return NotFound();
            
        }
    }
}
