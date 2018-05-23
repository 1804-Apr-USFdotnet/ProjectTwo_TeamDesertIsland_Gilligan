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

        public void AddSongToUser(UserSong userSong)
        {
            var userToUpdate = _userRepository.Get(userSong.User.UserId);
            var songToUpdate = _songRepository.Get(userSong.SongId);

            userSong.User = null;

            userToUpdate.UserSongs.Add(userSong);

            songToUpdate.IsAttached = true;

            _songRepository.SaveChanges();
            _userRepository.SaveChanges();
        }

        public void RemoveSongFromUser(UserSong userSong)
        {
            _userRepository.DeleteUserSong(userSong);

            var songToUpdate = _songRepository.Get(userSong.SongId);

            songToUpdate.IsAttached = false;

            _songRepository.SaveChanges();
        }

        public void AddSong(Song song)
        {
            var album = _albumRepository.Get(song.Album.AlbumId);
            var artists = _artistRepository.Get(song.Artists).ToList();

            song.Album = album;
            song.Artists = artists;

            _songRepository.Add(song);
        }

        public void AddAlbum(Album album)
        {
            _albumRepository.Add(album);
        }

        public void AddArtist(Artist artist)
        {
            var genres = _genreRepository.Get(artist.Genres).ToList();

            artist.Genres = genres;

            _artistRepository.Add(artist);
        }

        public void AddGenre(Genre genre)
        {
            _genreRepository.Add(genre);
        }
    }
}
