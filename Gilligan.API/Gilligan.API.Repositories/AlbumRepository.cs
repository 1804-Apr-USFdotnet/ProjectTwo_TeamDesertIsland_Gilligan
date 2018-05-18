using System.Collections.Generic;
using System.Runtime.ExceptionServices;
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

        public Album Get(string name)
        {
            return 
        }
    }
}
