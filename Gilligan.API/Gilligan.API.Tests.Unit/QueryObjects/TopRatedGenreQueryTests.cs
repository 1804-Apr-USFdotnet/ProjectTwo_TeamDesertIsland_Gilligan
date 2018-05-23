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

        [TestMethod]
        public void Monthly_Empty_ReturnsGenresRatedInLastMonth()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
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
                },
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Ratings = new List<Rating>
                                    {
                                        new Rating
                                        {
                                            RatedOn = new DateTime(2000, 1, 1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _query = new TopRatedGenreQuery(genres, 3);

            var results = _query.Monthly();

            const int expected = 1;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void Weekly_Empty_ReturnsGenresRatedInLastWeek()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
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
                },
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Ratings = new List<Rating>
                                    {
                                        new Rating
                                        {
                                            RatedOn = DateTime.Today - TimeSpan.FromDays(8)
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _query = new TopRatedGenreQuery(genres, 3);

            var results = _query.Weekly();

            const int expected = 1;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void Daily_Empty_ReturnsGenresRatedToday()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
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
                },
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Ratings = new List<Rating>
                                    {
                                        new Rating
                                        {
                                            RatedOn = DateTime.Today - TimeSpan.FromDays(1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _query = new TopRatedGenreQuery(genres, 3);

            var results = _query.Daily();

            const int expected = 1;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void AllTime_Empty_ReturnsAllRatedGenres()
        {
            var genres = new List<Genre>
            {
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
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
                },
                new Genre
                {
                    Artists = new List<Artist>
                    {
                        new Artist
                        {
                            Songs = new List<Song>
                            {
                                new Song
                                {
                                    Ratings = new List<Rating>
                                    {
                                        new Rating
                                        {
                                            RatedOn = DateTime.Today - TimeSpan.FromDays(1)
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _query = new TopRatedGenreQuery(genres, 3);

            var results = _query.AllTime();

            const int expected = 2;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void Queries_Empty_ReturnsGenresBySongRatingDescending()
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

            var genres = new List<Genre> { firstGenre, secondGenre };

            _query = new TopRatedGenreQuery(genres, 3);

            var result = _query.Monthly();

            Assert.AreEqual(firstGenre, result.FirstOrDefault());
        }

        [TestMethod]
        public void Queries_Empty_ReturnsTakeAmount()
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

            var genres = new List<Genre> { firstGenre, secondGenre };

            _query = new TopRatedGenreQuery(genres, 1);

            var result = _query.AllTime();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }
    }
}
