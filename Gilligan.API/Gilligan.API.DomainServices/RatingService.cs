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

        public RatingService(IRatingRepository ratingRepository, ISongRepository songRepository, IUserRepository userRepository)
        {
            _ratingRepository = ratingRepository;
            _songRepository = songRepository;
            _userRepository = userRepository;
        }

        public void AddRating(Rating rating)
        {
            var song = _songRepository.Get(rating.Song.SongId);
            var user = _userRepository.Get(rating.User.UserId);

            rating.Song = song;
            rating.User = user;

            _ratingRepository.Add(rating);
        }

        public AlbumRatings AlbumRatings()
        {
            var query = new TopRatedAlbumQuery();

            return null;
        }

        public SongRatings SongRatings()
        {
            var songs = _songRepository.Get();

            var query = new TopRatedSongsQuery(songs);
        }

        public ArtistRatings ArtistRatings()
        {
            throw new System.NotImplementedException();
        }

        public GenreRatings GeneRatings()
        {
            throw new System.NotImplementedException();
        }
    }
}
