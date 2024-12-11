using Entities;

namespace Servicess
{
    public interface IOrderServices
    {
       
        Task<Order> GetById(int id);
        Task<Order> Post(Order Order);
    }
}