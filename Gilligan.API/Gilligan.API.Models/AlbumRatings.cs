using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class AlbumRatings
    {
        public IEnumerable<Album> TopDailyRatedAlbums { get; set; }
        public IEnumerable<Album> TopWeeklyRatedAlbums { get; set; }
        public IEnumerable<Album> TopMonthlyRatedAlbums { get; set; }
        public IEnumerable<Album> TopAllTimeRatedAlbums { get; set; }
    }
}
