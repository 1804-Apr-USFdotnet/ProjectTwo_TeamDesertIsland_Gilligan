using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.DomainServices
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ISongRepository _songRepository;
        private readonly IUserRepository _userRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IAlbumRepository _albumRepository;

        public RatingService(IRatingRepository ratingRepository, ISongRepository songRepository, IUserRepository userRepository, IArtistRepository artistRepository, IGenreRepository genreRepository, IAlbumRepository albumRepository)
        {
            _ratingRepository = ratingRepository;
            _songRepository = songRepository;
            _userRepository = userRepository;
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
            _albumRepository = albumRepository;
        }

        public void AddRating(Rating rating)
        {
            var song = _songRepository.Get(rating.Song.SongId);
            var user = _userRepository.Get(rating.User.UserId);

            rating.Song = song;
            rating.User = user;

            _ratingRepository.Add(rating);
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
