using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class OrderReposetory : IOrderReposetory
    {
        MyShop328120357Context myShop;
        public OrderReposetory(MyShop328120357Context myShop)
        {
            this.myShop = myShop;
        }
       

        public async Task<Order> GetById(int id)
        {
            return await myShop.Orders.FirstOrDefaultAsync(c => c.Id == id);

        }
        public async Task<Order> Post(Order Order)
        {
            await myShop.Orders.AddAsync(Order);
            await myShop.SaveChangesAsync();
            return Order;
        }


        

    }
}
