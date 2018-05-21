using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IDbContext _context;

        public AlbumRepository(IDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Album> Get()
        {
            return _context.Albums;
        }

        public IEnumerable<Album> Get(string name)
        {
            return _context.Albums.Where(x => x.Name == name);
        }
    }
}
