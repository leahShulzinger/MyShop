using Entities;

namespace Servicess
{
    public interface IOrderServicess
    {
       
        Task<Order> Get(int id);
        Task<Order> Post(Order Order);
       
    }
}