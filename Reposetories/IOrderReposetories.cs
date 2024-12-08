using Entities;

namespace Reposetories
{
    public interface IOrderReposetories
    {
        Task<List<Order>> Get();
        Task<Order> Get(int id);
        Task<Order> Post(Order Order);
    }
}