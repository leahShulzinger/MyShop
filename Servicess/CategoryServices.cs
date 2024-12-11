using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicess
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryReposetories reposetory;
        public CategoryServices(ICategoryReposetories reposetory)
        {
            this.reposetory = reposetory;
        }
        public async Task<List<Category>> Get()
        {
            return await reposetory.Get();
        }
       
    }
}
