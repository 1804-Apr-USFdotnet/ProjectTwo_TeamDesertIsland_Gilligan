using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface ISpotifyService
    {
        IEnumerable<Album> SearchAlbums(string album);
        IEnumerable<Song> SearchSongs(string song);
        IEnumerable<Artist> SearchArtists(string artist);
    }
}
