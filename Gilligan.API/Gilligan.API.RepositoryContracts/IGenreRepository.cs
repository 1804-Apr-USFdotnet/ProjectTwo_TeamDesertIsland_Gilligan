using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> Get();
        Genre Get(string name);
        void Add(Genre genre);
    }
}
