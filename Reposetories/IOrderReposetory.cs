using Entities;

namespace Reposetories
{
    public interface IOrderReposetory
    {
        
        Task<Order> GetById(int id);
        Task<Order> Post(Order Order);
    }
}