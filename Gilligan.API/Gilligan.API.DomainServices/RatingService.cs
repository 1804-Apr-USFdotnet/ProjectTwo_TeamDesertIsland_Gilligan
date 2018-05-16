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

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public void AddRating(Rating rating)
        {
            _ratingRepository.Add(rating);
        }

        public List<Rating> Get()
        {
            List<Rating> lsRatings = _ratingRepository.Get().ToList();
            
            return lsRatings;
        }
    }
}
