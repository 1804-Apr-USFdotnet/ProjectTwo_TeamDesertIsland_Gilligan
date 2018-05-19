using System;
using System.Collections.Generic;
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

        public void AddSongToUser(Song song)
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

        public IEnumerable<Genre> CreateGenreIsNotExists(Song song)
        {
            var genres = song.Artists.FirstOrDefault().Genres;

            var songGenres = new List<Genre>();

            foreach (var i in genres)
            {
                var searchResult = _genreRepository.Get(i.Name);

                if (_genreRepository.Get(i.Name) == null)
                {
                    var genre = new Genre
                    {
                        Id = Guid.NewGuid(),
                        GenreId = Guid.NewGuid(),
                        Name = i.Name
                    };
                    _genreRepository.Add(genre);
                    songGenres.Add(genre);
                }
                songGenres.Add(searchResult);
            }

            return songGenres;
        }

        public IEnumerable<Artist> CreateArtistIfNotExists(Song song)
        {
            throw new System.NotImplementedException();
        }

        public Album CreateAlbumIfNotExists(Song song)
        {
            throw new System.NotImplementedException();
        }

        public Song CreateSongIfNotExists(Song song)
        {
            var searchResult = _songRepository.Get(song.SongId);

            if (searchResult == null)
            {
                var newSong = new Song
                {
                    Album = CreateAlbumIfNotExists(song),
                    Artists = CreateArtistIfNotExists(song).ToList(),

                };
                var genres = CreateGenreIsNotExists(song);
                var artist = CreateArtistIfNotExists(song);
                var album = CreateAlbumIfNotExists(song);

                return newSong;
            }

            return searchResult;
        }
    }
}
