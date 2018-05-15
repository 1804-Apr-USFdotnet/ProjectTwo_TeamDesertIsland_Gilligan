using System.Collections.Generic;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

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
            throw new System.NotImplementedException();
        }

        public List<Rating> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}
