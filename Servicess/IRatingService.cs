using Entities;

namespace Servicess
{
    public interface IRatingService
    {
        Task<Rating> Post(Rating rating);
    }
}