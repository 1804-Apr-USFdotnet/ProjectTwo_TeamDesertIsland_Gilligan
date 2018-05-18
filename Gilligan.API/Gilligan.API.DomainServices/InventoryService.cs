using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.DomainServices
{
    public class InventoryService : IInventoryService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly ISongRepository _songRepository;

        public InventoryService(IGenreRepository genreRepository, IArtistRepository artistRepository, IAlbumRepository albumRepository, ISongRepository songRepository)
        {
            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _songRepository = songRepository;
        }

        public Genre CreateGenreIsNotExists(string genre)
        {
            var result = _genreRepository.Get(genre);

            return null;
        }

        public Artist CreateArtistIfNotExists(string artist)
        {
            var result = _artistRepository.Get(artist);

            return null;
        }

        public Album CreateAlbumIfNotExists(string album)
        {
            var result = _albumRepository.Get(album);

            return null;
        }

        public Song CreateSongIfNotExists(string song)
        {
            var result = _songRepository.Get(song);

            return null;
        }
    }
}
