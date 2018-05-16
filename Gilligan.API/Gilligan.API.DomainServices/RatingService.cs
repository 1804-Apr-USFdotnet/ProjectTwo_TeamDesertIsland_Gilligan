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
            if(rating == null)
            {
                throw new ArgumentException("Rating cannot be null!");
            }
            else
            {
                try
                {
                    _ratingRepository.Add(rating);
                }
                catch(Exception e)
                {
                    Console.WriteLine("Exception handled:\n" + e.Message + "\n");
                    Console.WriteLine("Stack Trace:\n" + e.StackTrace + "\n");
                    Console.WriteLine("Inner Exception:\n" + e.InnerException + "\n");
                    Console.WriteLine("\n" + e.InnerException.Message);
                }
            }
        }

        public List<Rating> Get()
        {
            List<Rating> lsRatings = new List<Rating>();

            try
            {
                lsRatings = _ratingRepository.Get().ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception handled:\n" + e.Message + "\n");
                Console.WriteLine("Stack Trace:\n" + e.StackTrace + "\n");
                Console.WriteLine("Inner Exception:\n" + e.InnerException + "\n");
                Console.WriteLine("\n" + e.InnerException.Message);
            }
            return lsRatings;
        }
    }
}
