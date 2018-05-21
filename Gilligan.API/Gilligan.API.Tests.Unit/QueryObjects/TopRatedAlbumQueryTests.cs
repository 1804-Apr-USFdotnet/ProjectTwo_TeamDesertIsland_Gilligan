using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Unit.QueryObjects
{
    [TestClass]
    public class TopRatedAlbumQueryTests
    {
        private TopRatedAlbumsQuery _query;
        private List<Album> _albums;

        [TestMethod]
        public void Monthly_Empty_ReturnsAlbumsRatedInTheLastMonth()
        {
            _albums = new List<Album>
            {
                new Album
                {
                    Songs = new List<Song>
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
                    }
                },
                new Album
                {
                    Songs = new List<Song>
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
                                    RatedOn = new DateTime(1999, 1, 1)
                                }
                            }
                        }
                    }
                }
            };

            _query = new TopRatedAlbumsQuery(_albums, 3);

            var result = _query.Monthly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Weekly_Empty_ReturnsAlbumsRatedInLastWeek()
        {

        }

        [TestMethod]
        public void Daily_Empty_ReturnsAlbumsRatedThatDay()
        {

        }

        [TestMethod]
        public void Queries_Empty_ReturnsAlbumsByRatingsDescending()
        {
            var firstAlbum = new Album
            {
                Songs = new List<Song>
                {
                    new Song
                    {
                        AverageRating = 5.0,
                        Ratings = new List<Rating>{new Rating { RatedOn = DateTime.Today} }
                    }
                }
            };
            var secondAlbum = new Album
            {
                Songs = new List<Song>
                {
                    new Song
                    {
                        AverageRating = 3.0,
                        Ratings = new List<Rating>{new Rating { RatedOn = DateTime.Today} }
                    }
                }
            };

            _albums = new List<Album>
            {
                firstAlbum, secondAlbum
            };

            _query = new TopRatedAlbumsQuery(_albums, 3);

            var result = _query.Monthly();

            Assert.AreEqual(firstAlbum, result.FirstOrDefault());
        }

        [TestMethod]
        public void Queries_Empty_ReturnsTakeAmount()
        {
            _albums = new List<Album>
            {
                new Album
                {
                    Songs = new List<Song>
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
                    }
                },
                new Album
                {
                    Songs = new List<Song>
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
                    }
                }
            };

            _query = new TopRatedAlbumsQuery(_albums, 1);

            var result = _query.Monthly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }
    }
}
