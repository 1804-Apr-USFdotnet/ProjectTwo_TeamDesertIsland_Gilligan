using System;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface ISongRepository
    {
        Song Get(Guid songId);
    }
}
