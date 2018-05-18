﻿using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface ISearchService
    {
        IEnumerable<Artist> SearchArtists(string artist);
        IEnumerable<Album> SearchAlbums(string album);
        IEnumerable<Song> SearchSongs(string song);
    }
}
