using Entities;

namespace Reposetories
{
    public interface IProductReposotory
    {
        Task<List<Product>> Get(string? desc, float? minPrice, float? maxPrice, int?[] categoryIds);

    }
}