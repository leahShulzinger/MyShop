using Entities;
using Microsoft.Extensions.Logging;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Servicess
{
        public class OrderServicess : IOrderServicess
        
    {
        //private readonly ILogger<OrderServicess> _logger;
        IOrderReposetories reposetory;
       IProductReposetories reposetory1;
        public OrderServicess(IOrderReposetories reposetory, IProductReposetories reposetory1)
        {
            this.reposetory = reposetory;
            this.reposetory1 = reposetory1;
        }
       
        public Task<Order> Get(int id)
        {

            return reposetory.Get(id);
        }
        public Task<Order> Post(Order Order)
        {
           Order goodOrder= getSum(Order);
            return reposetory.Post(goodOrder);
        }
        private Order getSum(Order Order)
        {
            float sum = 0;
            foreach (var product in Order.OrderItem)
            {
                Product goodProduct = reposetory1.GetById(product.Id);
                sum += goodProduct.Price;
            }
            if (Order.Sum != sum)
            {
              
                Order.Sum =  sum;
                //_logger.LogError("הכניס סכום בכוחות עצמו");
            }

            return Order;
        }

    }
}

