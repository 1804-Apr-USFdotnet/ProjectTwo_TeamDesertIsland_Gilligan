using System.Collections.Generic;
using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface IInventoryService
    {
        void AddSongToUser(Song song);
        void RemoveSongFromUser(Song song, User user);
        IEnumerable<Genre> CreateGenreIsNotExists(Song song);
        IEnumerable<Artist> CreateArtistIfNotExists(Song song);
        Album CreateAlbumIfNotExists(Song song);
        Song CreateSongIfNotExists(Song song);
    }
}
