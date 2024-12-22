using Entities;

namespace Servicess
{
    public interface IProductServicess
    {
        Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}