using Entities;

namespace Reposetories
{
    public interface IRatingReposetories
    {
        Task<Rating> Post(Rating rating);
    }
}