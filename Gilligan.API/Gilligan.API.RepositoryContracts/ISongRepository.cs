using System;
using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface ISongRepository
    {
        Song Get(Guid songId);
        IEnumerable<Song> Get();
        Song Get(string name);
    }
}
