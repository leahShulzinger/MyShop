using Entities;

namespace Reposetories
{
    public interface IProductReposotory
    {
        Task<List<Product>> Get();
       
    }
}