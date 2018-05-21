using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Unit.QueryObjects
{
    [TestClass]
    public class TopRatedGenreQueryTests
    {
        private TopRatedGenreQuery _query;
        private List<Genre> _genres;
        private List<Song> _songs;

        [TestMethod]
        public void Monthly_Empty_RaturnsGenresBySongRatingDescending()
        {
            var firstGenre = new Genre
            {
                Artists = new List<Artist>
                {
                    new Artist
                    {
                        Songs = new List<Song>
                        {
                            new Song
                            {
                                AverageRating = 5.0,
                                Ratings = new List<Rating>
                                {
                                    new Rating
                                    {
                                        RatedOn = DateTime.Today
                                    }    
                                }
                            }
                        }
                    }
                }
            };
            var secondGenre = new Genre
            {
                Artists = new List<Artist>
                {
                    new Artist
                    {
                        Songs = new List<Song>
                        {
                            new Song
                            {
                                AverageRating = 3.0,
                                Ratings = new List<Rating>
                                {
                                    new Rating
                                    {
                                        RatedOn = DateTime.Today
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var genres = new List<Genre>{firstGenre, secondGenre};

            _query = new TopRatedGenreQuery(genres, 3);

            var result = _query.Monthly();

            Assert.AreEqual(firstGenre, result.FirstOrDefault());
        }
    }
}
