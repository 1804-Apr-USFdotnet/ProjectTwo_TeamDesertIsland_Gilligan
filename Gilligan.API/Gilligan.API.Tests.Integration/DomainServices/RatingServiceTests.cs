using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.DomainServices
{
    [TestClass]
    public class RatingServiceTests
    {
        private readonly GilliganTestContext _context;
        private readonly RatingService _ratingService;

        public RatingServiceTests()
        {
            _context = new GilliganTestContext();
            _ratingService = new RatingService(new SongRepository(_context), new ArtistRepository(_context), new GenreRepository(_context), new AlbumRepository(_context), new UserRepository(_context));
        }

        [TestInitialize]
        public void ClearTables()
        {
            _context.Artists.RemoveRange(_context.Artists);
            _context.Albums.RemoveRange(_context.Albums);
            _context.Users.RemoveRange(_context.Users);
            _context.Songs.RemoveRange(_context.Songs);
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddRating_Rating_AddsRatingToDatabase()
        {
            var song = new Song {Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album{Id = Guid.NewGuid()}};
            var user = new User {Id = Guid.NewGuid(), UserId = Guid.NewGuid()};

            _context.Songs.Add(song);
            _context.Users.Add(user);
            _context.SaveChanges();

            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                Song = new Song { SongId = song.SongId},
                User = new User { UserId = user.UserId}
            };

            _ratingService.AddRating(rating);

            var ratings = _context.Ratings.ToList();

            Assert.IsTrue(ratings.Contains(rating));
        }

        [TestMethod]
        public void AlbumRatings_Int_ReturnsCorrectAlbumRatings()
        {
            var album = new List<Album>
            {
                new Album
                {
                    Id = Guid.NewGuid(),
                    Songs = new List<Song>
                    {
                        new Song
                        {
                            Id = Guid.NewGuid(),
                            Ratings = new List<Rating>
                            {
                                new Rating
                                {
                                    Id = Guid.NewGuid(),
                                    RatedOn = DateTime.Today,
                                    User = new User{Id = Guid.NewGuid()}
                                }
                            }
                        }
                    }
                }
            };

            _context.Albums.AddRange(album);
            _context.SaveChanges();

            var result = _ratingService.AlbumRatings(3);

            const int expected = 1;

            Assert.AreEqual(expected, result.TopDailyRatedAlbums.Count());
            Assert.AreEqual(expected, result.TopWeeklyRatedAlbums.Count());
            Assert.AreEqual(expected, result.TopMonthlyRatedAlbums.Count());
            Assert.AreEqual(expected, result.TopAllTimeRatedAlbums.Count());
        }

        [TestMethod]
        public void SongRatings_Int_ReturnsCorrectSongRatings()
        {
            var song = new Song
            {
                Id = Guid.NewGuid(),
                Album = new Album
                {
                    Id = Guid.NewGuid()
                },
                Ratings = new List<Rating>
                {
                    new Rating
                    {
                        Id = Guid.NewGuid(),
                        RatedOn = DateTime.Today, 
                        User = new User{Id = Guid.NewGuid()}
                    }
                }
            };

            _context.Songs.Add(song);
            _context.SaveChanges();

            var results = _ratingService.SongRatings(3);

            const int expected = 1;

            Assert.AreEqual(expected, results.TopDailyRatedSongs.Count());
            Assert.AreEqual(expected, results.TopWeeklyRatedSongs.Count());
            Assert.AreEqual(expected, results.TopMonthlyRatedSongs.Count());
            Assert.AreEqual(expected, results.TopAllTimeRatedSongs.Count());
        }

        [TestMethod]
        public void ArtistRatings_Int_ReturnsCorrectArtistRatings()
        {
            var artist = new Artist
            {
                Id = Guid.NewGuid(),
                Songs = new List<Song>
                {
                    new Song
                    {
                        Id = Guid.NewGuid(),
                        Ratings = new List<Rating>
                        {
                            new Rating
                            {
                                Id = Guid.NewGuid(),
                                RatedOn = DateTime.Today,
                                User = new User{Id = Guid.NewGuid()}
                            }
                        },
                        Album = new Album{Id = Guid.NewGuid()}
                    }
                }
            };

            _context.Artists.Add(artist);
            _context.SaveChanges();

            var results = _ratingService.ArtistRatings(3);

            const int expected = 1;

            Assert.AreEqual(expected, results.TopDailyRatedArtists.Count());
            Assert.AreEqual(expected, results.TopWeeklyRatedArtists.Count());
            Assert.AreEqual(expected, results.TopMonthlyRatedArtists.Count());
            Assert.AreEqual(expected, results.TopAllTimedRatedArtists.Count());
        }

        [TestMethod]
        public void GenreRatings_Int_ReturnsCorrectGenreRatings()
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Artists = new List<Artist>
                {
                    new Artist
                    {
                        Id = Guid.NewGuid(),
                        Songs = new List<Song>
                        {
                            new Song
                            {
                                Id = Guid.NewGuid(),
                                Album = new Album{Id = Guid.NewGuid()},
                                Ratings = new List<Rating>
                                {
                                    new Rating
                                    {
                                        Id = Guid.NewGuid(),
                                        RatedOn = DateTime.Today,
                                        User = new User{Id = Guid.NewGuid()}
                                    }
                                }
                            }
                        }
                    }
                }
            };

            _context.Genres.Add(genre);
            _context.SaveChanges();

            var results = _ratingService.GenreRatings(3);

            const int expected = 1;

            Assert.AreEqual(expected, results.TopDailyRatedGenres.Count());
            Assert.AreEqual(expected, results.TopWeeklyRatedGenres.Count());
            Assert.AreEqual(expected, results.TopMonthlyRatedGenres.Count());
            Assert.AreEqual(expected, results.TopAllTimeRatedGenres.Count());
        }
    }
}
