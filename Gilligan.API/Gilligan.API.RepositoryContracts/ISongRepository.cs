using System;
using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface ISongRepository
    {
        Song Get(Guid songId);
        IEnumerable<Song> Get();
        IEnumerable<Song> Get(string name);
        void SaveChanges();
    }
}
