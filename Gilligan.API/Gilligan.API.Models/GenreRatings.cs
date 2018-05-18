using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class GenreRatings
    {
        public IEnumerable<Genre> TopDailyRatedGenres { get; set; }
        public IEnumerable<Genre> TopWeeklyRatedGenres { get; set; }
        public IEnumerable<Genre> TopMonthlyRatedGenres { get; set; }
        public IEnumerable<Genre> TopAllTimeRatedGenres { get; set; }
    }
}
