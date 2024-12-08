using Entities;

namespace Servicess
{
    public interface IProductServicess
    {
        Task<List<Product>> Get();
        Task<Product> GetById(int id);
    
    }

    }