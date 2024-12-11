using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicess
{
    public class ProductServices : IProductServices
    {
        IProductReposotory reposetory;
        public ProductServices(IProductReposotory reposetory)
        {
            this.reposetory = reposetory;
        }
        public async Task<List<Product>> Get()
        {
            return await reposetory.Get();
        }
       
    }
}
