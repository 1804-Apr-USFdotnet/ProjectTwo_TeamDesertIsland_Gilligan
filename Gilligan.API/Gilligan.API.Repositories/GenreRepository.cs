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

        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public IEnumerable<Genre> Get(IEnumerable<Genre> genres)
        {
            return genres.Select(i => _context.Genres.First(x => x.GenreId == i.GenreId)).ToList();
        }
    }
}
