using System.Collections.Generic;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.DomainServices
{
    public class SearchService : ISearchService
    {
        private readonly ISongRepository _songRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;

        public SearchService(ISongRepository songRepository, IAlbumRepository albumRepository, IArtistRepository artistRepository, IGenreRepository genreRepository)
        {
            _songRepository = songRepository;
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
        }

        public IEnumerable<Song> SearchLocalSongs(string value)
        {
            var songs = _songRepository.Get();

            var query = new MusicEntityPartialSearchQuery();

            return query.AsExpression(songs, value);
        }

        public IEnumerable<Album> SearchLocalAlbums(string value)
        {
            var albums = _albumRepository.Get();

            var query = new MusicEntityPartialSearchQuery();

            return query.AsExpression(albums, value);
        }

        public IEnumerable<Artist> SearchLocalArtists(string value)
        {
            var artists = _artistRepository.Get();

            var query = new MusicEntityPartialSearchQuery();

            return query.AsExpression(artists, value);
        }

        public IEnumerable<Genre> SearchLocalGenres(string value)
        {
            var genres = _genreRepository.Get();

            var query = new MusicEntityPartialSearchQuery();

            return query.AsExpression(genres, value);
        }
    }
}
