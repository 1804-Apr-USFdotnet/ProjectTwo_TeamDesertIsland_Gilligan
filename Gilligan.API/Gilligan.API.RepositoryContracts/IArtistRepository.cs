using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> Get();
        Artist Get(string name);
    }
}
