using System;
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

        public void Add(Album album)
        {
            _context.Albums.Add(album);
            _context.SaveChanges();
        }

        public Album Get(Guid albumId)
        {
            return _context.Albums.First(x => x.AlbumId == albumId);
        }
    }
}
