using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IRatingRepository
    {
        void Add(Rating rating);
        IEnumerable<Rating> Get();
    }
}
