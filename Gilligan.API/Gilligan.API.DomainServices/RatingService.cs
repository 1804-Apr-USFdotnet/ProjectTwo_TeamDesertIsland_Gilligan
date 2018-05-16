using System.Collections.Generic;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;
using System.Linq;
using System;

namespace Gilligan.API.DomainServices
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ISongRepository _songRepository;
        private readonly IUserRepository _userRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public void AddRating(Rating rating)
        {
            var song = _songRepository.Get(rating.Song.SongId);
            var user = _userRepository.Get(rating.User.UserId);
            rating.Song = song;
            rating.User = user;
            _ratingRepository.Add(rating);
        }

        public List<Rating> Get()
        {
            return _ratingRepository.Get().ToList();
        }
    }
}
