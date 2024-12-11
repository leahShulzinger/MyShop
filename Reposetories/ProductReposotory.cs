using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class ProductReposotory:IProductReposotory
    {
        MyShop328120357Context myShop;
        public ProductReposotory(MyShop328120357Context myShop)
        {
            this.myShop = myShop;

        }
        public async Task<List<Product>> Get()
        {
            var products = await myShop.Products.ToListAsync();
            return products;
        }
        
    }
}
