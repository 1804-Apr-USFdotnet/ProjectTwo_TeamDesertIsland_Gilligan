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
    public class InventoryControllerTests
    {
        private readonly InventoryController _inventoryController;
        private readonly Mock<IInventoryService> _inventoryService;

        public InventoryControllerTests()
        {
            var container = Bootstrapper.RegisterTypes();
            var mapper = container.Resolve<IMapper>();

            _inventoryService = new Mock<IInventoryService>();
            _inventoryService.Setup(x => x.AddSongToUser(It.IsAny<UserSong>()));
            _inventoryService.Setup(x => x.RemoveSongFromUser(It.IsAny<UserSong>()));
            _inventoryService.Setup(x => x.AddSong(It.IsAny<Song>()));
            _inventoryService.Setup(x => x.AddArtist(It.IsAny<Artist>()));
            _inventoryService.Setup(x => x.AddGenre(It.IsAny<Genre>()));
            _inventoryService.Setup(x => x.AddAlbum(It.IsAny<Album>()));

            _inventoryController = new InventoryController(_inventoryService.Object, mapper);
        }

        [TestMethod]
        public void AddSongToUser_InvalidModelState_ReturnBadRequest()
        {
            _inventoryController.ModelState.AddModelError("Error", "Bad");

            var result = _inventoryController.AddSongToUser(new AddRemoveUserSongViewModel());

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void AddSongToUser_AddRemoveUserSongViewModel_CallsServiceMethod()
        {
            _inventoryController.AddSongToUser(new AddRemoveUserSongViewModel());

            _inventoryService.Verify(x => x.AddSongToUser(It.IsAny<UserSong>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddSongToUser_AddRemoveUserSongViewModel_ReturnsOk()
        {
            var result = _inventoryController.AddSongToUser(new AddRemoveUserSongViewModel());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void RemoveSongFromUser_InvalidModelState_ReturnsBadRequest()
        {
            _inventoryController.ModelState.AddModelError("Error", "Bad");

            var result = _inventoryController.RemoveSongFromUser(new AddRemoveUserSongViewModel());

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void RemoveSongFromUser_AddRemoveUserSongViewModel_CallsServiceMethod()
        {
            var result = _inventoryController.RemoveSongFromUser(new AddRemoveUserSongViewModel());

            _inventoryService.Verify(x => x.RemoveSongFromUser(It.IsAny<UserSong>()));
        }

        [TestMethod]
        public void RemoveSongFromUser_AddRemoveUserSongViewModel_ReturnsOk()
        {
            var result = _inventoryController.RemoveSongFromUser(new AddRemoveUserSongViewModel());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void AddSongToInventory_InvalidModelState_ReturnsBadRequest()
        {
            _inventoryController.ModelState.AddModelError("Error", "Bad");

            var result = _inventoryController.AddSongToInventory(new AddSongViewModel());

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void AddSongToInvenstory_AddSongViewModel_CallsServiceMethod()
        {
            _inventoryController.AddSongToInventory(new AddSongViewModel());

            _inventoryService.Verify(x => x.AddSong(It.IsAny<Song>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddSongToInventory_AddSongViewModel_ReturnsOk()
        {
            var result = _inventoryController.AddSongToInventory(new AddSongViewModel());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void AddAlbumToInventory_InvalidModelState_ReturnsBadRequest()
        {
            _inventoryController.ModelState.AddModelError("Error", "Bad");

            var result = _inventoryController.AddAlbumToInventory(new AddAlbumViewModel());

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void AddAlbumToInventory_AddAlbumViewModel_CallsServiceMethod()
        {
            var result = _inventoryController.AddAlbumToInventory(new AddAlbumViewModel());

            _inventoryService.Verify(x => x.AddAlbum(It.IsAny<Album>()));
        }

        [TestMethod]
        public void AddAlbumToInventory_AddAlbumViewModel_ReturnsOk()
        {
            var result = _inventoryController.AddAlbumToInventory(new AddAlbumViewModel());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void AddArtistToInventory_InvalidModelState_ReturnsBadRequest()
        {
            _inventoryController.ModelState.AddModelError("Error", "Bad");

            var result = _inventoryController.AddArtistToInventory(new AddArtistViewModel());

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void AddArtistToInventory_AddArtistViewModel_CallsServiceMethod()
        {
            _inventoryController.AddArtistToInventory(new AddArtistViewModel());

            _inventoryService.Verify(x => x.AddArtist(It.IsAny<Artist>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddArtistToInventory_AddArtistViewModel_ReturnsOK()
        {
            var result = _inventoryController.AddArtistToInventory(new AddArtistViewModel());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void AddGenreToInventory_InvalidModelState_ReturnsBadRequest()
        {
            _inventoryController.ModelState.AddModelError("Error", "Bad");

            var result = _inventoryController.AddGenreToInventory(new AddGenreViewModel());

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void AddGenreToInventory_AddArtistViewModel_CallsServiceMethod()
        {
            _inventoryController.AddGenreToInventory(new AddGenreViewModel());

            _inventoryService.Verify(x => x.AddGenre(It.IsAny<Genre>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddGenreToInventory_AddArtistViewModel_ReturnsOk()
        {
            var result = _inventoryController.AddGenreToInventory(new AddGenreViewModel());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
