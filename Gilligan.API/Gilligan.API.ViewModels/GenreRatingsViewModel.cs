using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class GenreRatingsViewModel
    {
        public IEnumerable<GenreViewModel> TopDailyRatedGenreViewModels { get; set; }
        public IEnumerable<GenreViewModel> TopWeeklyRatedGenreViewModels { get; set; }
        public IEnumerable<GenreViewModel> TopMonthlyRatedGenreViewModels { get; set; }
        public IEnumerable<GenreViewModel> TopAllTimeRatedGenreViewModels { get; set; }
    }
}
