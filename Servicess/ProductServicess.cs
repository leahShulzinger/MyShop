using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicess
{
    public class ProductServicess :IProductServicess
    {
        IProductReposetories reposetory;
        public ProductServicess(IProductReposetories reposetory)
        {
            this.reposetory = reposetory;
        }
        public async Task<List<Product>> Get(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await reposetory.Get(desc, minPrice, maxPrice, categoryIds);
        }


    }
}
