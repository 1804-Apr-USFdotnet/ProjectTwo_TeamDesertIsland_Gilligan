using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Unit.QueryObjects
{
    [TestClass]
    public class TopRatedSongsQueryTests
    {
        private TopRatedSongsQuery _query;
        private List<Song> _songs;

        [TestMethod]
        public void Monthly_NoParameter_ReturnsSongsByRatingDescending()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = DateTime.Today
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 3);

            var result = _query.Monthly();

            const double expected = 3.0;

            Assert.AreEqual(expected, result.First().AverageRating);
        }

        [TestMethod]
        public void Monthly_NoParameter_ReturnsSongsRatedInLastMonth()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = new DateTime(2000, 1, 1)
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 3);

            var result = _query.Monthly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Monthly_NoParameter_ReturnsTakeAmount()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = DateTime.Today
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 1);

            var result = _query.Monthly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Weekly_NoParameter_ReturnsSongsByRatingDescending()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = DateTime.Today
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 3);

            var result = _query.Weekly();

            const double expected = 3.0;

            Assert.AreEqual(expected, result.First().AverageRating);
        }

        [TestMethod]
        public void Weekly_NoParameter_ReturnsSongsRatedInLastWeek()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = new DateTime(2000, 1, 1)
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 3);

            var result = _query.Weekly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Weekly_NoParameter_ReturnsTakeAmount()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = DateTime.Today
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 1);

            var result = _query.Weekly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void AllTime_NoParameter_ReturnsSongsByRatingDescending()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = DateTime.Today
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 3);

            var result = _query.AllTime();

            const double expected = 3.0;

            Assert.AreEqual(expected, result.First().AverageRating);
        }

        [TestMethod]
        public void AllTime_NoParameter_ReturnsTakeAmount()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    AverageRating = 1.0,
                    Ratings = new List<Rating>
                    {
                        new Rating
                        {
                            RatedOn = DateTime.Today
                        }
                    }
                },
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
            };

            _query = new TopRatedSongsQuery(_songs, 1);

            var result = _query.AllTime();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Daily_Empty_ReturnsSongsRatedOnThatDay()
        {
            _songs = new List<Song>
            {
                new Song
                {
                    Ratings = new List<Rating>
                    {
                        new Rating{RatedOn = DateTime.Today}
                    }
                },
                new Song
                {
                    Ratings = new List<Rating>
                    {
                        new Rating{RatedOn = new DateTime(2000, 1, 1)}
                    }
                }
            };

            _query = new TopRatedSongsQuery(_songs, 3);

            var result = _query.Daily();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }
    }
}
