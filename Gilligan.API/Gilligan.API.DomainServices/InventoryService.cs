using System;
using System.Linq;
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
        private readonly IUserRepository _userRepository;

        public InventoryService(IGenreRepository genreRepository, IArtistRepository artistRepository, IAlbumRepository albumRepository, ISongRepository songRepository, IUserRepository userRepository)
        {
            _genreRepository = genreRepository;
            _artistRepository = artistRepository;
            _albumRepository = albumRepository;
            _songRepository = songRepository;
            _userRepository = userRepository;
        }

        public void AddSongToUser(Song song, User user)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSongFromUser(Song song, User user)
        {
            var userToUpdate = _userRepository.Get(user.UserId);

            var userSong = userToUpdate.UserSongs.First(x => x.SongId == song.SongId);

            var songToUpdate = _songRepository.Get(userSong.SongId);

            songToUpdate.IsAttached = false;

            _songRepository.SaveChanges();
        }

        public void AddSong(Song song)
        {
            throw new NotImplementedException();
        }

        public void AddAlbum(Album album)
        {
            throw new NotImplementedException();
        }

        public void AddArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void AdllGenre(Genre genre)
        {
            throw new NotImplementedException();
        }
    }
}
