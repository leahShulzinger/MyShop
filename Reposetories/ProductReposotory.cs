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
        
            public async Task<List<Product>> Get(string? desc, float? minPrice, float? maxPrice, int?[] categoryIds)
            {

                var query = myShop.Products.Where(product =>
                    (desc == null ? (true) : (product.ProductName.Contains(desc)))
                    && (((minPrice) == null) ? (true) : (product.Price >= minPrice))
                    && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
                    && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                   .OrderBy(product => product.Price);
                Console.WriteLine(query.ToQueryString());
                List<Product> products = await query.Include(c=>c.Category).ToListAsync();
                return products;
            //List<Product> product = await myShop.Products.Include(c => c.Category).ToListAsync();
            //return product;
        }
        //var products = await myShop.Products.Include(c => c.Category).ToListAsync();
        //    return products;


    }
}
