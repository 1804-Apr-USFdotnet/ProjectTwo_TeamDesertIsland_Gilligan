using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Autofac;
using AutoMapper;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Gilligan.API.Rest;
using Gilligan.API.Rest.Controllers;
using Gilligan.API.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Rest
{
    [TestClass]
    public class RatingControllerTests
    {
        private readonly RatingController _ratingController;
        private readonly GilliganTestContext _context;

        public RatingControllerTests()
        {
            var container = Bootstrapper.RegisterTypes();
            var mapper = container.Resolve<IMapper>();
            _context = new GilliganTestContext();
            _ratingController = new RatingController(new RatingService(new SongRepository(_context), new ArtistRepository(_context), new GenreRepository(_context), new AlbumRepository(_context), new UserRepository(_context)), mapper);
        }

        [TestInitialize]
        public void ClearTables()
        {
            _context.Artists.RemoveRange(_context.Artists);
            _context.Albums.RemoveRange(_context.Albums);
            _context.Genres.RemoveRange(_context.Genres);
            _context.Users.RemoveRange(_context.Users);
            _context.Songs.RemoveRange(_context.Songs);
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddRating_AddRatingViewModel_RatesSong()
        {
            var user = new User {Id = Guid.NewGuid(), UserId = Guid.NewGuid()};
            var song = new Song{Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album{Id = Guid.NewGuid()}};

            _context.Users.Add(user);
            _context.Songs.Add(song);
            _context.SaveChanges();

            var viewModel = new AddRatingViewModel
            {
                RatedOn = DateTime.Today,
                SongId = song.SongId,
                UserId = user.UserId
            };

            _ratingController.AddRating(viewModel);

            var ratings = _context.Ratings.ToList();

            const int expected = 1;

            Assert.AreEqual(expected, ratings.Count);
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

            var result = _ratingController.AlbumRatings(3) as OkNegotiatedContentResult<AlbumRatingsViewModel>;

            const int expected = 1;

            Assert.AreEqual(expected, result.Content.TopDailyAlbumViewModels.Count());
            Assert.AreEqual(expected, result.Content.TopWeeklyRatedAlbumViewModels.Count());
            Assert.AreEqual(expected, result.Content.TopMonthlyRatedAlbumViewModels.Count());
            Assert.AreEqual(expected, result.Content.TopAllTimeRatedAlbumViewModels.Count());
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

            var results = _ratingController.SongRatings(3) as OkNegotiatedContentResult<SongRatingsViewModel>;

            const int expected = 1;

            Assert.AreEqual(expected, results.Content.TopDailyRatedSongViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopWeeklyRatedSongViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopMonthlyRatedSongViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopAllTimeRatedSongViewModels.Count());
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

            var results = _ratingController.ArtistRatings(3) as OkNegotiatedContentResult<ArtistRatingsViewModel>;

            const int expected = 1;

            Assert.AreEqual(expected, results.Content.TopDailyArtistViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopWeeklyRatedArtistViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopMonthlyRatedArtistViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopAllTimeRatedArtistViewModels.Count());
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

            var results = _ratingController.GenreRatings(3) as OkNegotiatedContentResult<GenreRatingsViewModel>;

            const int expected = 1;

            Assert.AreEqual(expected, results.Content.TopDailyRatedGenreViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopWeeklyRatedGenreViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopMonthlyRatedGenreViewModels.Count());
            Assert.AreEqual(expected, results.Content.TopAllTimeRatedGenreViewModels.Count());
        }
    }
}
