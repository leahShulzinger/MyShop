using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicess
{
    public class OrderServicess : IOrderServicess
    {
        IOrderReposetories reposetory;
        public OrderServicess(IOrderReposetories reposetory)
        {
            this.reposetory = reposetory;
        }
        public Task<List<Order>> Get()
        {

            return reposetory.Get();

        }
        public Task<Order> Get(int id)
        {

            return reposetory.Get(id);
        }
        public Task<Order> Post(Order Order)
        {
            return reposetory.Post(Order);
        }

        //public Task<Order> Put(int id, Order OrderToUpdate)
        //{

        //    return reposetory.(id, OrderToUpdate);


        //}

    }
}

