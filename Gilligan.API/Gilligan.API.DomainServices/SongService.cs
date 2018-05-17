using System;
using System.Collections.Generic;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;
using System.Linq;

namespace Gilligan.API.DomainServices
{
    public class SongService : ISongService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ISongRepository _songRepository;
        private readonly IUserRepository _userRepository;

        public SongService(IRatingRepository ratingRepository, ISongRepository songRepository, IUserRepository userRepository)
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

        public List<Rating> Get()
        {
            return _ratingRepository.Get().ToList();
        }
    }
}
