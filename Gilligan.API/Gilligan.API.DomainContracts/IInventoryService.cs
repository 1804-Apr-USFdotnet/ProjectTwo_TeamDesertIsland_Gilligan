using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface IInventoryService
    {
        Genre CreateGenreIsNotExists(string genre);
        Artist CreateArtistIfNotExists(string artist);
        Album CreateAlbumIfNotExists(string album);
        Song CreateSongIfNotExists(string song);
    }
}
