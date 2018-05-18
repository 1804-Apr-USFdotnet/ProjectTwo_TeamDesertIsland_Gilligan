using Gilligan.API.Models;

namespace Gilligan.API.DomainContracts
{
    public interface IRatingService
    {
        void AddRating(Rating rating);
        AlbumRatings AlbumRatings(int takeAmount);
        SongRatings SongRatings(int takeAmount);
        ArtistRatings ArtistRatings(int takeAmount);
        GenreRatings GenreRatings(int takeAmount);
    }
}
