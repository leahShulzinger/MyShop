using Entities;

namespace Servicess
{
    public interface IOrderServicess
    {
        public Task<List<Order>> Get();
        Task<Order> Get(int id);
        Task<Order> Post(Order Order);
        //Task<Order> Put(int id, Order OrderToUpdate);
    }
}