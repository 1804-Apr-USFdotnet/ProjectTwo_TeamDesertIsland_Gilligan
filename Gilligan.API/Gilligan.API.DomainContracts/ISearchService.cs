using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface ISearchService
    {
        IEnumerable<Song> SearchLocalSongs(string value);
        IEnumerable<Album> SearchLocalAlbums(string value);
        IEnumerable<Artist> SearchLocalArtists(string value);
        IEnumerable<Genre> SearchLocalGenres(string value);
    }
}
