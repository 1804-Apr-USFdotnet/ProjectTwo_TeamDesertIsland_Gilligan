using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> Get();
        IEnumerable<Album> Get(string name);
    }
}
