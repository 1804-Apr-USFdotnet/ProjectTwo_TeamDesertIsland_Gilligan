using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly IDbContext _context;

        public SongRepository(IDbContext context)
        {
            _context = context;
        }

        public Song Get(Guid songId)
        {
            return _context.Songs.First(x => x.SongId == songId);
        }

        public IEnumerable<Song> Get()
        {
            return _context.Songs;
        }
    }
}
