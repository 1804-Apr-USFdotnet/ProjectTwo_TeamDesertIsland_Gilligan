using System;
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
            var userToUpdate = _userRepository.Get(user.UserId);

            var userSong = new UserSong
            {
                Id = Guid.NewGuid(),
                UserSongId = Guid.NewGuid()
                SongId = song.SongId
            };

            userToUpdate.UserSongs.Add(userSong);

            _userRepository.SaveChanges();
        }

        public void RemoveSongFromUser(Song song, User user)
        {
            _userRepository.DeleteUserSong(user, song);

            var songToUpdate = _songRepository.Get(song.SongId);

            songToUpdate.IsAttached = false;

            _songRepository.SaveChanges();
        }

        public void AddSong(Song song)
        {
            _songRepository.Add(song);
        }

        public void AddAlbum(Album album)
        {
            _albumRepository.Add(album);
        }

        public void AddArtist(Artist artist)
        {
            _artistRepository.Add(artist);
        }

        public void AddGenre(Genre genre)
        {
            _genreRepository.Add(genre);
        }
    }
}
