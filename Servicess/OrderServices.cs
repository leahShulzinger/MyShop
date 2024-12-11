using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicess
{
    public class OrderServices : IOrderServices
    {
        IOrderReposetory reposetory;
        public OrderServices(IOrderReposetory reposetory)
        {
            this.reposetory = reposetory;

        }

        public async Task<Order> GetById(int id)
        {
            return await reposetory.GetById(id);

        }
        public async Task<Order> Post(Order Order)
        {
            return await reposetory.Post(Order);
        }

    }
}
