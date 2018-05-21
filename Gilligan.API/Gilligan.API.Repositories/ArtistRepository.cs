using System.Collections.Generic;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IDbContext _context;

        public ArtistRepository(IDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Artist> Get()
        {
            return _context.Artists;
        }
    }
}
