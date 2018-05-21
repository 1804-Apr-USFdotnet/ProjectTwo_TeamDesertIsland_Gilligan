using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface ISearchService
    {
        IEnumerable<Song> SearchSpotifySongs(string name);
        IEnumerable<Song> SearchLocalSongs(string name);
        IEnumerable<Album> SearchLocalAlbums(string name);
        IEnumerable<Artist> SearchLocalArtists(string name);
        IEnumerable<Genre> SearchLocalGenres(string name);
    }
}
