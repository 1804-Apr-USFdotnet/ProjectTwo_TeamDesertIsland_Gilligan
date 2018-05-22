using System.Web.Http.Results;
using Autofac;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.Rest;
using Gilligan.API.Rest.Controllers;
using Gilligan.API.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gilligan.API.Tests.Unit.Rest
{
    [TestClass]
    public class RatingControllerTests
    {
        private readonly RatingController _ratingController;

        public RatingControllerTests()
        {
            var ratingService = new Mock<IRatingService>();
            ratingService.Setup(x => x.AddRating(It.IsAny<Rating>()));
            ratingService.Setup(x => x.SongRatings(It.IsAny<int>())).Returns(new SongRatings());
            ratingService.Setup(x => x.ArtistRatings(It.IsAny<int>())).Returns(new ArtistRatings());
            ratingService.Setup(x => x.GenreRatings(It.IsAny<int>())).Returns(new GenreRatings());
            ratingService.Setup(x => x.AlbumRatings(It.IsAny<int>())).Returns(new AlbumRatings());

            var container = Bootstrapper.RegisterTypes();
            var mapper = container.Resolve<IMapper>();

            _ratingController = new RatingController(ratingService.Object, mapper);
        }

        [TestMethod]
        public void AddRating_InvalidAddRatingViewModel_ReturnsBadRequest()
        {
            _ratingController.ModelState.AddModelError("Error", "Bad");

            var result = _ratingController.AddRating(new AddRatingViewModel());

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void AddRating_ValidAddRatingViewModel_ReturnsOk()
        {
            var result = _ratingController.AddRating(new AddRatingViewModel());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void SongRatings_Int_ReturnsOkResult()
        {
            var result = _ratingController.SongRatings(new int());

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<SongRatingsViewModel>));
        }

        [TestMethod]
        public void SongRatings_Int_ReturnsCorrectType()
        {
            var result = _ratingController.SongRatings(new int());

            var resultType = result as OkNegotiatedContentResult<SongRatingsViewModel>;

            Assert.IsInstanceOfType(resultType.Content, typeof(SongRatingsViewModel));
        }

        [TestMethod]
        public void AlbumRatings_Int_ReturnsOkResult()
        {
            var result = _ratingController.AlbumRatings(new int());

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<AlbumRatingsViewModel>));
        }

        [TestMethod]
        public void AlbumRatings_Int_ReturnsCorrectType()
        {
            var result = _ratingController.AlbumRatings(new int());

            var resultType = result as OkNegotiatedContentResult<AlbumRatingsViewModel>;

            Assert.IsInstanceOfType(resultType.Content, typeof(AlbumRatingsViewModel));
        }

        [TestMethod]
        public void ArtistRatings_Int_ReturnsOkResult()
        {
            var result = _ratingController.ArtistRatings(new int());

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ArtistRatingsViewModel>));
        }

        [TestMethod]
        public void ArtistRatings_Int_ReturnsCorrectType()
        {
            var result = _ratingController.ArtistRatings(new int());

            var resultType = result as OkNegotiatedContentResult<ArtistRatingsViewModel>;

            Assert.IsInstanceOfType(resultType.Content, typeof(ArtistRatingsViewModel));
        }

        [TestMethod]
        public void GenreRatings_Int_ReturnsOkResult()
        {
            var result = _ratingController.GenreRatings(new int());

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<GenreRatingsViewModel>));
        }

        [TestMethod]
        public void GenreRatings_Int_ReturnsCorrectType()
        {
            var result = _ratingController.GenreRatings(new int());

            var resultType = result as OkNegotiatedContentResult<GenreRatingsViewModel>;

            Assert.IsInstanceOfType(resultType.Content, typeof(GenreRatingsViewModel));
        }
    }
}
