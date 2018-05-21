using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface IInventoryService
    {
        void AddSongToUser(Song song, User user);
        void RemoveSongFromUser(Song song, User user);
        void AddSong(Song song);
        void AddAlbum(Album album);
        void AddArtist(Artist artist);
        void AdllGenre(Genre genre);
    }
}
