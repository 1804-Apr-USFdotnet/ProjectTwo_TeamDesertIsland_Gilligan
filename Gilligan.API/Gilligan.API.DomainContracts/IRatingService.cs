using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface IRatingService
    {
        void AddRating(Rating rating);
        List<Rating> Get();
    }
}
