using Entities;

namespace Servicess
{
    public interface IRatingServicess
    {
        Task<Rating> Post(Rating rating);
    }
}