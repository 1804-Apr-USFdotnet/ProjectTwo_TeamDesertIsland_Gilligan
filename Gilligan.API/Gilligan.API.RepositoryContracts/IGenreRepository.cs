using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Get();
        void Add(Genre genre);
    }
}
