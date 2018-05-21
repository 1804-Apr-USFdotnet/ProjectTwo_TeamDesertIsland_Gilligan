﻿using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> Get();
        IEnumerable<Artist> Get(string name);
    }
}