using Gilligan.API.DomainContracts;
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
        private readonly IUserRepository _userRepository;

        public RatingService(ISongRepository songRepository, IArtistRepository artistRepository, IGenreRepository genreRepository, IAlbumRepository albumRepository, IUserRepository userRepository)
        {
            _songRepository = songRepository;
            _artistRepository = artistRepository;
            _genreRepository = genreRepository;
            _albumRepository = albumRepository;
            _userRepository = userRepository;
        }

        public void AddRating(Rating rating)
        {
            var song = _songRepository.Get(rating.Song.SongId);
            var user = _userRepository.Get(rating.User.UserId);

            rating.Song = null;
            rating.User = user;

            song.Ratings.Add(rating);
            _songRepository.SaveChanges();
        }

        public AlbumRatings AlbumRatings(int takeAmount)
        {
            var albums = _albumRepository.Get();

            var query = new TopRatedAlbumsQuery(albums, takeAmount);

            return new AlbumRatings
            {
                TopAllTimeRatedAlbums = query.AllTime(),
                TopDailyRatedAlbums = query.Daily(),
                TopWeeklyRatedAlbums = query.Weekly(),
                TopMonthlyRatedAlbums = query.Monthly()
            };
        }

        public SongRatings SongRatings(int takeAmount)
        {
            var songs = _songRepository.Get();

            var query = new TopRatedSongsQuery(songs, takeAmount);

            return new SongRatings
            {
                TopAllTimeRatedSongs = query.AllTime(),
                TopDailyRatedSongs = query.Daily(),
                TopWeeklyRatedSongs = query.Weekly(),
                TopMonthlyRatedSongs = query.Monthly()
            };
        }

        public ArtistRatings ArtistRatings(int takeAmount)
        {
            var artists = _artistRepository.Get();

            var query = new TopRatedArtistsQuery(artists, takeAmount);

            return new ArtistRatings
            {
                TopAllTimedRatedArtists = query.AllTime(),
                TopDailyRatedArtists = query.Daily(),
                TopWeeklyRatedArtists = query.Weekly(),
                TopMonthlyRatedArtists = query.Monthly()
            };
        }

        public GenreRatings GenreRatings(int takeAmount)
        {
            var albums = _genreRepository.Get();

            var query = new TopRatedGenreQuery(albums, takeAmount);

            return new GenreRatings
            {
                TopAllTimeRatedGenres = query.AllTime(),
                TopDailyRatedGenres = query.Daily(),
                TopWeeklyRatedGenres = query.Weekly(),
                TopMonthlyRatedGenres = query.Monthly()
            };
        }
    }
}
