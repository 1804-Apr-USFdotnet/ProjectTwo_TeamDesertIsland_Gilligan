using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class ArtistRatings
    {
        public IEnumerable<Artist> TopDailyRatedArtists { get; set; }
        public IEnumerable<Artist> TopWeeklyRatedArtists { get; set; }
        public IEnumerable<Artist> TopMonthlyRatedArtists { get; set; }
        public IEnumerable<Artist> TopAllTimedRatedArtists { get; set; }
    }
}
