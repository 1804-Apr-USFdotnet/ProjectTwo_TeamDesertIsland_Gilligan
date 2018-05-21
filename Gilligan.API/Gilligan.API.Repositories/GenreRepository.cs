using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IDbContext _context;

        public GenreRepository(IDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> Get()
        {
            return _context.Genres;
        }

        public IEnumerable<Genre> Get(string name)
        {
            return _context.Genres.Where(x => x.Name == name);
        }

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }
}
