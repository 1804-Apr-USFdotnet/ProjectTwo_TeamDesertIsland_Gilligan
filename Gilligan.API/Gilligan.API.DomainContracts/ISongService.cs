using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface ISongService
    {
        void AddRating(Rating rating);
        List<Rating> Get();
    }
}
