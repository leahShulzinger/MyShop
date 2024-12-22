using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class OrderReposetories : IOrderReposetories
    {
        MyShop214935017Context myShop;
        public OrderReposetories(MyShop214935017Context myShop)
        {
            this.myShop = myShop;
        }

        public async Task<Order> Get(int id)
        {
            return await myShop.Orders.Include(u => u.User).Include(o => o.OrderItems).FirstOrDefaultAsync(order => order.Id == id);




        }
        public async Task<Order> Post(Order Order)
        {
            await myShop.Orders.AddAsync(Order);
            await myShop.SaveChangesAsync();
            return Order;

        }



    }
}
