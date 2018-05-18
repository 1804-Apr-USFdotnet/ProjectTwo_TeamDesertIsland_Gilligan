﻿using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.DomainServices
{
    public class RatingService : IRatingService
    {
        private readonly ISongRepository _songRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IInventoryService _inventoryService;

        public RatingService(ISongRepository songRepository, IArtistRepository artistRepository, IGenreRepository genreRepository, IAlbumRepository albumRepository, IInventoryService inventoryService)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
            _albumRepository = albumRepository;
            _inventoryService = inventoryService;
        }

        public void AddRating(Rating rating)
        {
            
        }

        public AlbumRatings AlbumRatings(int takeAmount)
        {
            var albums = _albumRepository.Get();

            var query = new TopRatedAlbumQuery();

            return null;
        }

        public SongRatings SongRatings(int takeAmount)
        {
            var songs = _songRepository.Get();

            var query = new TopRatedSongsQuery(songs, takeAmount);

            return null;
        }

        public ArtistRatings ArtistRatings(int takeAmount)
        {
            var artists = _artistRepository.Get();

            var query = new TopRatedArtistsQuery(artists, takeAmount);

            return null;
        }

        public GenreRatings GenreRatings(int takeAmount)
        {
            var albums = _genreRepository.Get();

            var query = new TopRatedGenreQuery();

            return null;
        }
    }
}
