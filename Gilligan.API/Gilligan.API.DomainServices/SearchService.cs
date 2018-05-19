using System.Collections.Generic;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.DomainServices
{
    public class SearchService : ISearchService
    {
        private readonly ISpotifyService _spotifyService;
        private readonly ISongRepository _songRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;

        public SearchService(ISpotifyService spotifyService, ISongRepository songRepository, IAlbumRepository albumRepository, IArtistRepository artistRepository, IGenreRepository genreRepository)
        {
            _spotifyService = spotifyService;
            _songRepository = songRepository;
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
        }

        public IEnumerable<Song> SearchSpotifySongs(string name)
        {
            var songs = _spotifyService.SearchSongs(name);

            //map with existing

            return null;
        }

        public IEnumerable<Song> SearchLocalSongs(string name)
        {
            return _songRepository.Get(name);
        }

        public IEnumerable<Album> SearchLocalAlbums(string name)
        {
            return _albumRepository.Get(name);
        }

        public IEnumerable<Artist> SearchLocalArtists(string name)
        {
            return _artistRepository.Get(name);
        }

        public IEnumerable<Genre> SearchLocalGenres(string name)
        {
            return null;
            //return _genreRepository.Get(name);
        }
    }
}
