using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class SongRatings
    {
        public IEnumerable<Song> TopDailyRatedSongs { get; set; }
        public IEnumerable<Song> TopWeeklyRatedSongs { get; set; }
        public IEnumerable<Song> TopMonthlyRatedSongs { get; set; }
        public IEnumerable<Song> TopAllTimeRatedSongs { get; set; } 
    }
}
