using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface IInventoryService
    {
        void AddSongToUser(UserSong userSong);
        void RemoveSongFromUser(UserSong userSong);
        void AddSong(Song song);
        void AddAlbum(Album album);
        void AddArtist(Artist artist);
        void AddGenre(Genre genre);
    }
}
