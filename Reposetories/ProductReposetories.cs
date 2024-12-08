using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposetories
{
    public class ProductReposetories : IProductReposetories
    {
        MyShop214935017Context myShop;
        public ProductReposetories(MyShop214935017Context myShop)
        {
            this.myShop = myShop;
        }
        //List<Product>products=new();
        public async Task<List<Product>> Get()
        {
           List<Product> products = await myShop.Products.ToListAsync();
            return products;
        }

        public async Task <Product> GetById(int id)
        {
            Product product = await myShop.Products.FirstOrDefaultAsync(currentProduct=>currentProduct.Id==id);
            return product;
        }
    }
}
