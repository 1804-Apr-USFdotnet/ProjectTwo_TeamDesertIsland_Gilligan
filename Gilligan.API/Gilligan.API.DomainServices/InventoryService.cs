﻿using System;
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

            var userSongToAdd = new UserSong
            {
                Id = Guid.NewGuid(),
                UserSongId = Guid.NewGuid(),
                SongId = userSong.SongId
            };

            userToUpdate.UserSongs.Add(userSongToAdd);

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
