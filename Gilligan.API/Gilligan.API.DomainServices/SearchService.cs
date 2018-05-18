using System.Collections.Generic;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;

namespace Gilligan.API.DomainServices
{
    public class SearchService : ISearchService
    {
        private readonly ISpotifyService _spotifyService;
        private readonly IRatingService _ratingService;

        public SearchService(ISpotifyService spotifyService, IRatingService ratingService)
        {
            _spotifyService = spotifyService;
            _ratingService = ratingService;
        }

        public IEnumerable<Artist> SearchArtists(string artist)
        {
            return _spotifyService.SearchArtists(artist);
        }

        public IEnumerable<Album> SearchAlbums(string album)
        {
            return _spotifyService.SearchAlbums(album);
        }

        public IEnumerable<Song> SearchSongs(string song)
        {
            return _spotifyService.SearchSongs(song);
        }
    }
}
