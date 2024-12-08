using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicess
{
    public class CategoryServicess : ICategoryServicess
    {
        ICategoryReposetories reposetory;
        public CategoryServicess(ICategoryReposetories reposetory)
        {
            this.reposetory = reposetory;
        }
        public async Task<List<Category>> Get()
        {
            return await reposetory.Get();

        }
        public async Task<Category> GetById(int id)
        {
            return await reposetory.GetById(id);

        }

    }
}
