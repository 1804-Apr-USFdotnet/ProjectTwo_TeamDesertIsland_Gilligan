﻿using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> Get();
        void Add(Artist artist);
        IEnumerable<Artist> Get(IEnumerable<Artist> artists);
    }
}
