
using Entities;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicess
{
    public class RatingService : IRatingService
    {
        IRatingReposetory reposetory;
        public RatingService(IRatingReposetory reposetory)
        {
            this.reposetory = reposetory;
        }
        public Task<Rating> Post(Rating rating)
        {

            return reposetory.Post(rating);


        }
    }
}
