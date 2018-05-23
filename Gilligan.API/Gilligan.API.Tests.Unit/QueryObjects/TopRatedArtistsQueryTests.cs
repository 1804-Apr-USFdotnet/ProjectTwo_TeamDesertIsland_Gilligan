using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.QueryObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Unit.QueryObjects
{
    [TestClass]
    public class TopRatedArtistsQueryTests
    {
        private TopRatedArtistsQuery _query;
        private List<Artist> _artists;

        [TestMethod]
        public void  Monthly_NoParameter_ReturnsArtistsBySongRatingDescending()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 3);

            var result = _query.Monthly();

            const string expected = "The Doors";

            Assert.AreEqual(expected, result.First().Name);
        }

        [TestMethod]
        public void Monthly_NoParameter_ReturnsArtistsBySongsRatedInLastMonth()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 3);

            var result = _query.Monthly();

            const int expected = 2;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Monthly_NoParameter_ReturnsTakeAmount()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 1);

            var result = _query.Monthly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Weekly_NoParameter_ReturnsArtistsBySongRatingDescending()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 3);

            var result = _query.Weekly();

            const string expected = "The Doors";

            Assert.AreEqual(expected, result.First().Name);
        }

        [TestMethod]
        public void Weekly_NoParameter_ReturnsArtistsSongsRatedInLastWeek()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 3);

            var result = _query.Weekly();

            const int expected = 2;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void Weekly_NoParameter_ReturnsTakeAmount()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 1);

            var result = _query.Weekly();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void AllTime_NoParameter_ReturnsArtistsSongsByRatingDescending()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 3);

            var result = _query.AllTime();

            const string expected = "The Doors";

            Assert.AreEqual(expected, result.First().Name);
        }

        [TestMethod]
        public void AllTime_NoParameter_ReturnsTakeAmount()
        {
            _artists = new List<Artist>
            {
                new Artist
                {
                    Name = "The Doors",
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            AverageRating = 2.0,
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
                            AverageRating = 4.0,
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
                            AverageRating = 1.0,
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    RatedOn = DateTime.Today
                                }
                            }
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "Psychadelic Rock"
                        },
                        new Genre
                        {
                            Name = "Alternative Rock"
                        }
                    }
                },
                new Artist
                {
                    Name = "Van Halen",
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
                            AverageRating = 2.0,
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
                        },
                    },
                    Genres = new List<Genre>
                    {
                        new Genre
                        {
                            Name = "Classic Rock"
                        },
                        new Genre
                        {
                            Name = "80s Rock"
                        },
                        new Genre
                        {
                            Name = "Glam Rock"
                        }
                    }
                }
            };

            _query = new TopRatedArtistsQuery(_artists, 1);

            var result = _query.AllTime();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }
    }
}
