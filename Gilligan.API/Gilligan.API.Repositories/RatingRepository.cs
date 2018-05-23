using System.Collections.Generic;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly IDbContext _dbContext;

        public RatingRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Rating rating)
        {
            _dbContext.Ratings.Add(rating);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Rating> Get()
        {
            return _dbContext.Ratings;
        }
    }
}
