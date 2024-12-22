using Entities;

namespace Reposetories
{
    public interface IOrderReposetories
    {

        Task<Order> Get(int id);
        Task<Order> Post(Order Order);
    }
}