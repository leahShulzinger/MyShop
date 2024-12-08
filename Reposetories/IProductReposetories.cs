using Entities;

namespace Reposetories
{
    public interface IProductReposetories
    {
        Task<List<Product>> Get();
        Task<Product> GetById(int id);
    }
}