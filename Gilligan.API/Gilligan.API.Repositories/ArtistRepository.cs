﻿using System.Collections.Generic;
using System.Linq;
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

        public void Add(Artist artist)
        {
            _context.Artists.Add(artist);
            _context.SaveChanges();
        }

        public IEnumerable<Artist> Get(IEnumerable<Artist> artists)
        {
            return artists.Select(i => _context.Artists.First(x => x.ArtistId == i.ArtistId)).ToList();
        }
    }
}
