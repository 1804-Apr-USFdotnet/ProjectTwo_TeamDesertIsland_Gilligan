using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> Get();
        void Add(Album album);
    }
}
