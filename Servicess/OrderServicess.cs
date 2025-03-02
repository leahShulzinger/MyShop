using Entities;
using Microsoft.Extensions.Logging;

//using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OrderServicess> _logger;
        IOrderReposetories reposetory;
       IProductReposetories reposetory1;
        public OrderServicess(IOrderReposetories reposetory, IProductReposetories reposetory1, ILogger<OrderServicess> _logger)
        {
            this.reposetory = reposetory;
            this.reposetory1 = reposetory1;
            this._logger = _logger;
        }
       
        public Task<Order> Get(int id)
        {

            return reposetory.Get(id);
        }
        public async Task<Order> Post(Order Order)
        {
           Order goodOrder=await getSum(Order);
            return await reposetory.Post(goodOrder);
        }
        private async Task< Order> getSum(Order Order)
        {
            float sum = 0;
            foreach (var product in Order.OrderItems)
            {
                Product goodProduct =await reposetory1.GetById(product.ProductId);
                sum +=(float)goodProduct.Price;
            }
            if (Order.Sum != sum)
            {
              
                Order.Sum =  sum;
                _logger.LogError("הכניס סכום בכוחות עצמו");
            }

            return Order;
        }

    }
}

